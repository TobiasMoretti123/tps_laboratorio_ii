﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        public enum ETipo { CuatroPuertas, CincoPuertas }
        ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : this (marca, chasis, color,ETipo.CuatroPuertas)
        {
        }

        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            :base (chasis, marca, color)
        {
            this.tipo = tipo;
        }
        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override Vehiculo.ETamanio Tamanio
        {
            get
            {
                return Vehiculo.ETamanio.Mediano;
            }
        }

        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine((string)this);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
