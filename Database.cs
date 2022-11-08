using DonacionesBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;
using DonacionesBackend.Modelos;

namespace DonacionesBackend
{

    public static class Database
    {

        private static readonly LiteDatabase m_Database = new LiteDatabase("donaciones.db");
        private static ILiteCollection<Donantes> m_Donantes;

        public static ILiteCollection<Donantes> Donantes => m_Donantes;

        public static void Init()
        {
            m_Donantes = m_Database.GetCollection<Donantes>("donantes");
        }

    }



}