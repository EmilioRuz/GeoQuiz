
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GeoQuiz.GUI.Models;

namespace GeoQuiz.GUI.ViewModels
{
    public class ModeloPreguntaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int indiceActual;
        public int indiceActual2;
        private string esCorrecto;
        private int totalRespondidas;
        private int totalCorrectas;
        public string pactual="";
        public ObservableCollection<ModeloPregunta> preguntas;
        public ObservableCollection<ModeloPregunta> Preguntas
        {
            get => preguntas;
            set
            {
                if (preguntas != value)
                {
                    preguntas = value;
                    OnPropertyChanged();
                }
            }
        }

        public int IndiceActual
        {
            get => indiceActual;
            set
            {
                if (indiceActual != value)
                {
                    indiceActual = value;
                    OnPropertyChanged();
                }
            }
        }
        public int IndiceActual2
        {
            get => indiceActual2;
            set
            {
                if (indiceActual2 != value)
                {
                    indiceActual2 = value;
                    OnPropertyChanged();
                }
            }
        }

        public string EsCorrecto
        {
            get => esCorrecto;
            set
            {
                esCorrecto = value;
                OnPropertyChanged();
            }
        }

        public int TotalRespondidas
        {
            get => totalRespondidas;
            set
            {
                totalRespondidas = value;
                OnPropertyChanged();
            }
        }

        public string PreguntaActual
        {
            get => pactual;
            set
            {
                pactual = value;
                OnPropertyChanged();
            }
        }

    
        public int TotalCorrectas
        {
            get => totalCorrectas;
            set
            {
                totalCorrectas = value;
                OnPropertyChanged();
            }
        }

        public ICommand ComandoCierto => new Command(() => VerificarRespuesta(true));
        public ICommand ComandoFalso => new Command(() => VerificarRespuesta(false));
        public ICommand ComandoSiguiente => new Command( ()=>  SiguientePregunta(IndiceActual));
        public ICommand ComandoAnterior => new Command(() => PreguntaAnterior(IndiceActual));

        public ModeloPreguntaViewModel()
        {
            IndiceActual = 0;
            IndiceActual2 = IndiceActual + 1;
            CargarPreguntas();
            
           
            
         
        }

        private void CargarPreguntas()
        {
            Preguntas = new ObservableCollection<ModeloPregunta>
            {
                new ModeloPregunta { Pregunta = "¿La Tierra gira alrededor del Sol?", Respuesta = true },
                new ModeloPregunta { Pregunta = "¿El agua hierve a 100 grados Celsius a nivel del mar?", Respuesta = true },
                new ModeloPregunta { Pregunta = "¿El ser humano puede respirar bajo el agua sin ayuda de equipo?", Respuesta = false },
                new ModeloPregunta { Pregunta = "¿La Mona Lisa fue pintada por Leonardo da Vinci?", Respuesta = true },
                new ModeloPregunta { Pregunta = "¿La Gran Muralla China es visible desde la Luna?", Respuesta = false },
            };
            PreguntaActual = Preguntas[IndiceActual].Pregunta.ToString();


        }

        private void VerificarRespuesta(bool respuestaUsuario)
        {
            TotalRespondidas++;

            if (Preguntas != null && IndiceActual >= 0 && IndiceActual < Preguntas.Count)
            {
                var preguntaActual = Preguntas[IndiceActual];

                if (respuestaUsuario == preguntaActual.Respuesta)
                {
                    EsCorrecto = "Es correcto";
                    TotalCorrectas++;
                }
                else
                {
                    EsCorrecto = "Es Incorrecto";
                    Console.WriteLine("Advertencia: Preguntas es nulo o no contiene elementos.");

                }
            }
            Console.WriteLine(IndiceActual);
        }

        private void  SiguientePregunta(int valor)
        {
            Console.WriteLine("SiguientePregunta llamado");
            EsCorrecto = "Es Correcto";

            //   IndiceActual = indiceActual + 1;
            // this.lbp.Text= Preguntas[IndiceActual].Pregunta.ToString();
            if (valor == (Preguntas.Count - 1))
            {
                IndiceActual = Preguntas.Count - 1;
                IndiceActual2 = Preguntas.Count;
            }
            else
            {
                IndiceActual = valor + 1;
                IndiceActual2 = IndiceActual + 1;
            }
            Console.WriteLine(IndiceActual);
            PreguntaActual = Preguntas[indiceActual].Pregunta.ToString();

        }


        private void PreguntaAnterior(int valor)
        {
            Console.WriteLine("PreguntaAnterior llamado");
            EsCorrecto = "Es Incorrecto";
            if (valor == 0)
            {
                IndiceActual = 0;
                IndiceActual2 = IndiceActual + 1;
            }
            else
            {
                IndiceActual = valor - 1;
                IndiceActual2 = valor ;
            }
            PreguntaActual = Preguntas[indiceActual].Pregunta.ToString();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Console.WriteLine($"Propiedad cambiada: {propertyName}");

        }
    }
}


