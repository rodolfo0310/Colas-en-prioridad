using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace colas 
{
    class SQueue : Queue, IComparer
    {
        public SQueue()
            : base()
        {
        }
        int IComparer.Compare(Object x, Object y)//comparar para sort
        {
            Datos _Dx, _Dy;
            int comparacion = 0;
            _Dx = (Datos)x;
            _Dy = (Datos)y;
            if (_Dy._prioridad < _Dx._prioridad)
                comparacion = -1;
            if (_Dy._prioridad > _Dx._prioridad)
                comparacion = 1;
            return comparacion;
        }
        public void SEnqueue(object[] pa)
        {
            ArrayList paq = new ArrayList(pa.ToArray());
            paq.Sort(this);
            foreach (Datos x in paq)
            {
                Enqueue(x);
            }

        }

    }
    public enum Prioridad
    {
        Bk = 0, Be = 1, EE = 2, Ca = 3, VI = 4, VO = 5, IC = 6, NC = 7
    }
    class Datos
    {
        private string _IpOrigen;
        public string _iporigen
        {
            get { return _IpOrigen; }
            set { _IpOrigen = value; }
        }
        private string _IpDestino;
        public string _ipdestino
        {
            get { return _IpDestino; }
            set { _IpDestino = value; }
        }
        private byte _Prioridad;
        public byte _prioridad
        {
            get { return _Prioridad; }
            set { _Prioridad = value; }
        }
        private Prioridad _priority;
        Int64[] _Data;
        public Datos(string ipo, string ipd, byte prioridad, Int64[] Data)
        {
            _priority = (Prioridad)prioridad;
            _ipdestino = ipd;
            _iporigen = ipo;
            _Prioridad = prioridad;
            _Data = Data;
        }
        public override string ToString()
        {
            return "Prioridad=" + _Prioridad;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SQueue CoS = new SQueue();
            ArrayList p0 = new ArrayList();
            ArrayList p1 = new ArrayList();
            ArrayList p2 = new ArrayList();
            ArrayList p3 = new ArrayList();
            ArrayList p4 = new ArrayList();
            ArrayList p5 = new ArrayList();
            ArrayList p6 = new ArrayList();
            ArrayList p7 = new ArrayList();

            byte op;

            for (; ; )
            {
                Console.WriteLine("Presione la opcion que desea\n1.-Ingresar Encolar Datos\n2.-Terminar el programa");
                op = Convert.ToByte(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        ResibirDatos(CoS);
                        break;
                    case 2:
                        Terminar(CoS, p0, p1, p2, p3, p4, p5, p6, p7);
                        break;
                }
                if (op == 2)
                    break;
            }
            Console.WriteLine();
        }
        static void ResibirDatos(SQueue s)
        {
            Console.Clear();
            Random rnd = new Random();
            byte prioridad;
            Datos[] Paquetes = new Datos[50];
            Int64[] _datos = new Int64[5] { 100101101011001, 101010111000100011, 101010001000100, 10101110000001, 01010101010101 };
            Console.WriteLine("Generando paquetes");
            for (int i = 0; i < 50; i++)
            {
                prioridad = (byte)rnd.Next(0, 8);
                Paquetes[i] = new Datos("192.168.1.89", "192.168.1.155", prioridad, _datos);
            }
            Console.WriteLine("....");
            Console.ReadKey();
            Console.WriteLine("Encolando los paquetes en proceso");
            Console.ReadKey();
            Console.WriteLine("Paquetes encolados con exito.");
            Console.ReadKey();
            Console.Clear();
            s.SEnqueue(Paquetes);
        }
        static void Terminar(SQueue s, ArrayList p0, ArrayList p1, ArrayList p2, ArrayList p3, ArrayList p4, ArrayList p5, ArrayList p6, ArrayList p7)
        {
            int i = s.Count;
            Datos aux;
            int paux;
            for (; i > 0; i--)
            {
                aux = (Datos)s.Dequeue();
                paux = aux._prioridad;
                switch (paux)
                {
                    case 0:
                        p0.Add(aux);
                        break;
                    case 1:
                        p1.Add(aux);
                        break;
                    case 2:
                        p2.Add(aux);
                        break;
                    case 3:
                        p3.Add(aux);
                        break;
                    case 4:
                        p4.Add(aux);
                        break;
                    case 5:
                        p5.Add(aux);
                        break;
                    case 6:
                        p6.Add(aux);
                        break;
                    case 7:
                        p7.Add(aux);
                        break;

                }
            }
        }
    }
}
