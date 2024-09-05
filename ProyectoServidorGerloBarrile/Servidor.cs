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
        private BinaryWriter lector; //facilita la lectura del flujo


        //inicaliza el proceso para la lecutra
        private void Servidor_Load(object sender, EventArgs e)
        {
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
                if( e.KeyCode == Keys.Enter && entradaTxt.ReadOnly == false)
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
}
