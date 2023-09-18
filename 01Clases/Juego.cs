using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Clases
{
    public class Juego
    {

        public Juego(string titulo, int anno, genero genero, plataforma plataforma)
        {
            Titulo = titulo;
            Anno = anno;
            Genero = genero;
            Plataforma = plataforma;
        }

        public Juego()
        {
            
        }


        public string titulo;

		public string Titulo
		{
			get { return titulo; }
			set { titulo = value; }
		}

		public int anno;

		public int Anno
		{
			get { return anno; }
			set { anno = value; }
		}

		public enum genero { Accion, Arcade, Estrategia, Aventura, Deportes, Simulacion};

		public genero _genero;

		public genero Genero
		{
			get { return _genero; }
			set { _genero = value; }
		}

		public enum plataforma { PC, PlayStation, Xbox, Nintendo};

		public plataforma _plataforma;

		public plataforma Plataforma
		{
			get { return _plataforma; }
			set { _plataforma = value; }
		}

        public override string ToString()
        {
            return $"Titulo: {titulo}, Año: {anno}, Genero: {Genero}, Plataforma: {Plataforma}" + '\n';
        }


    }
}
