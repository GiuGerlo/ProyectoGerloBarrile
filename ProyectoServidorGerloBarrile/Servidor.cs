using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;



namespace ProyectoServidorGerloBarrile
{
    public partial class Servidor : Form
    {
        public Servidor()
        {
            InitializeComponent();
        }

        private Socket conexion; //Socket para aceptar la conexion
        private Thread lecturaThread; //Thread para procesar los mensajes entrantes
        private NetworkStream socketStream; //flujo de datos en la red
        private BinaryWriter escritor; // facilita la escritura en el flujo
        private BinaryReader lector; //facilita la lectura del flujo



        public string ObtenerIPLocal()
        {
            string ipLocal = string.Empty;

            // Obtiene las direcciones IP del host local
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                // Filtra solo las direcciones IPv4
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ipLocal = ip.ToString();
                    break; // Se detiene en la primera IP IPv4 que encuentre
                }
            }

            return ipLocal;
        }
        //inicaliza el proceso para la lecutra
        private void Servidor_Load(object sender, EventArgs e)
        {
            direccionTxt.Text = ObtenerIPLocal();

            lecturaThread = new Thread(new ThreadStart(EjecutarServidor));
            lecturaThread.Start();
        } // fin del metodo


        //cierra todos los procesos asociados con esta aplicacion
        private void Servidor_FormClosing(object sender, FormClosingEventArgs e) {

            System.Environment.Exit(System.Environment.ExitCode);
        
        } //fin del metodo Closing

        //permite que s llame al metodo MostrarMensaje en el subproceso que crea y mantiene a la GUI
        private delegate void DisplayDelegate(string mensaje);


        //el DisplayDelegate establece la propiedad Text de salidaTxt
        private void MostrarMensaje(string mensaje)
        {

            if (salidaTxt.InvokeRequired)
            {
                Invoke(new DisplayDelegate(MostrarMensaje), new object[] { mensaje });

            }
            else salidaTxt.Text += mensaje;
        
        }   //fin del metodo MostrarMensaje

        //deshabilitar salida
        private delegate void DisableInputDelegate(bool value);

        //DeshabilitarEntrada establece ReadOnly
        private void DeshabilitarEntrada( bool valor)
        {
            if (entradaTxt.InvokeRequired)
            {
                Invoke(new DisableInputDelegate(DeshabilitarEntrada), new object[] { valor });
            }
            else entradaTxt.ReadOnly = valor;
        }//fin del DeshabilitarEntrada

        //envia al cliente el texto escrito por el servidor
        private void entradaTxt_KeyDown( object sender, KeyEventArgs e)
        {
            try
            {
                if( e.KeyCode == Keys.Enter && entradaTxt.ReadOnly == false && escritor != null)
                {
                    escritor.Write("SERVIDOR>>> " + entradaTxt.Text);
                    salidaTxt.Text += "\r\nSERVIDOR>>> " + entradaTxt.Text;
                   if (entradaTxt.Text == "TERMINAR") 
                    conexion.Close();

                    entradaTxt.Clear(); //borra la entrada del usuario
                }



            } catch (SocketException)
                {
                salidaTxt.Text += "\nError al escribir objeto";
                } //fin catch


         }

        public void EjecutarServidor()
        {
            TcpListener oyente;
            int contador = 1;

            // Espera conexión y muestra el texto que envía el cliente
            try
            {
                // Paso 1: Crea TcpListener
                string ipUsuario = direccionTxt.Text; // Obtiene la IP ingresada por el usuario
                IPAddress local = IPAddress.Parse(ipUsuario); // Parsea la IP desde el campo de texto

                oyente = new TcpListener(local, 50000);

                // Paso 2: Espera la solicitud de conexión
                oyente.Start();

                // Paso 3: Establece la conexión con base en la solicitud del cliente
                while (true)
                {
                    MostrarMensaje("Esperando la conexión\r\n");

                    // Acepta una conexión entrante
                    conexion = oyente.AcceptSocket();

                    // Crea obj asociado con el socket
                    socketStream = new NetworkStream(conexion);

                    // Crea obj para transferir datos a través de un flujo
                    escritor = new BinaryWriter(socketStream);
                    lector = new BinaryReader(socketStream);

                    MostrarMensaje("Conexión " + contador + " recibida.\r\n");

                    // Informa al cliente conexión exitosa
                    escritor.Write("Servidor>>> Conexión exitosa");

                    DeshabilitarEntrada(false); // Habilita la entrada del entradaTxt

                    string respuesta = "";

                    // Paso 4: Lee los datos del string enviado
                    do
                    {
                        try
                        {
                            // Lee la string que se envía al cliente
                            respuesta = lector.ReadString();

                            // Muestra el mensaje
                            MostrarMensaje("\r\n" + respuesta);

                        }
                        catch (Exception)
                        {
                            // Maneja la excepción si hay error al leer datos
                            break;
                        }
                    } while (respuesta != "Cliente >>> TERMINAR" && conexion.Connected);

                    MostrarMensaje("\r\n El usuario terminó la conexión \r\n");

                    // Paso 5: Cierra la conexión
                    escritor.Close();
                    lector.Close();
                    socketStream.Close();
                    conexion.Close();

                    DeshabilitarEntrada(true);
                    contador++;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        } // fin método EjecutarServidor
 //fin metodo EjecutarServido

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void direccionTxt_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    } //fin clase
}
