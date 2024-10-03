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
using System.Net.Sockets;
using System.IO;

namespace ProyectoClienteGiulianoGerlo
{
    public partial class ClienteChatFrm : Form
    {
        public ClienteChatFrm()
        {
            InitializeComponent();

        }

        private NetworkStream salida; //flujo para recibir los datos
        private BinaryWriter escritor; //facilita la estructura en el flujo
        private BinaryReader lector; //facilita la lectura del flujo
        private Thread lecturaThread; //Thread para procesar mensajes entrantes
        private string mensaje = "";

        //inicia el subproceso para lectura
        private void ClienteChatFrm_Load( object sender, EventArgs e)
        {
            lecturaThread = new Thread(new ThreadStart(EjecutarCliente));
            lecturaThread.Start();
        } //fin del metodo ClienteChatFrm_Load

        //cierra todos los subprocesos asociados con esta aplicacion
        private void ClienteChatFrm_FormClosing (object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        } //fin del metodo ClienteChatFrm_FormClosing

        //delegado que permite llamar al metodo MostrarMensaje
        //en el subproceso que  crea y mantiene la GUI
        private delegate void DisplayDelegate (string message);

        //el MostrarMensaje establece la propiedad Text de salidaTxt
        //en una manera segura para el subproceso
        private void MostrarMensaje ( string mensaje)
        {
            //si la modificacion de salidaTxt no es segura para el subproceso
            if (salidaTxt.InvokeRequired)
            {
                //usa el metodo heredado Invoke para MostrarMensaje a traves de un delegado
                Invoke(new DisplayDelegate(MostrarMensaje), new object[] { mensaje });
            } //fin de if
            else //se puede modificar salidaTxt en el subproceso actual
                salidaTxt.Text += mensaje;
        } // fin del MostrarMensaje

        //delegado que permite llamar al metodo DeshabilitarSalida en el subproceso que crea
        // y mantiene la GUI
        private delegate void DisableInputDelegate(bool value);

        //el metodo DeshabilitarSalida establece la propiedad ReadOnly de entradaTxt
        // de una manera segura para el subproceso
        private void DeshabilitarSalida ( bool valor)
        {
            //si la modificacion de entradaTxt no es segura para el subproceso
            if (entradaTxt.InvokeRequired)
            {
                //usa el metodo heredado Invoke para ejecutar a DeshabilitarSalida a
                //traves de un delegado
                Invoke(new DisableInputDelegate(DeshabilitarSalida), new object[] { valor });
            }
            else //se puede modificar entradaTxt en el subproceso actual
                entradaTxt.ReadOnly = valor;
        } //fin del metodo DeshabilitarSalida

        //envia al servidor el texto que escribe el usuario
        private void entradaTxt_KeyDown( object sender, KeyEventArgs e)
        {
            try
            {
                if ( e.KeyCode == Keys.Enter && entradaTxt.ReadOnly == false)
                {
                    escritor.Write("CLIENTE>>> " + entradaTxt.Text);
                    salidaTxt.Text += "\r\nCLIENTE>>> " + entradaTxt.Text;
                    entradaTxt.Clear();
                }
            }
            catch (SocketException)
            {
                salidaTxt.Text += "\nError al escribir el objeto";
            }

        }//fin del entradaTxt_KeyDown

        //se conecta al servidor y muestra el texto generado por el servidor
        public void EjecutarCliente()
        {
            TcpClient cliente;

            //crea instancia TcpClient para enviar datos al servidor
            try
            {
                MostrarMensaje("Tratando de conectar a\r\n");

                //Paso 1 : crear TcpClient y conectar al servidor
                cliente = new TcpClient();
                cliente.Connect("127.0.0.1", 50000);

                //Paso 2: obtener NetworkStream asociado con TcpClient
                salida = cliente.GetStream();

                //crea objetos para escribir y leer el flujo
                escritor = new BinaryWriter(salida);
                lector = new BinaryReader(salida);

                MostrarMensaje("\r\nSe recibieron flujos de E/s\r\n");
                DeshabilitarSalida(false); //Habilita entradaTxt

                //itera hasta que el servidor indica la terminacion
                do
                {
                    //paso 3: fase de procesamiento
                    try
                    {
                        //lee el mensaje del servidor
                        mensaje = lector.ReadString();
                        MostrarMensaje("\r\n" + mensaje);
                    }//fin del try
                    catch (Exception)
                    {
                        //maneja excepcion si hay error al leer datos del servidor
                        System.Environment.Exit(System.Environment.ExitCode);
                    }//fin del catch
                } while (mensaje != "SERVIDOR>>> TERMINAR");

                //PASO 4: Cierra la conexion
                escritor.Close();
                lector.Close();
                salida.Close();
                cliente.Close();
                Application.Exit();
            } //fin de try
            catch (Exception error)
            {
                //maneja excepcion si hay error al establecer la conexion
                MessageBox.Show(error.ToString(), "Error en la conexion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }// fin de catch
        }



        private void salidaTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
} //fin de ClienteChatFrm
