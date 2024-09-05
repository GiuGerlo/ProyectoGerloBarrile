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

    }
}
