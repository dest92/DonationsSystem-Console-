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

        private static LiteDatabase m_Database;
        private static ILiteCollection<Donantes> m_Donantes;

        public static ILiteCollection<Donantes> Donantes => m_Donantes;

        public static void Init(string databaseName = "donaciones.db")
        {
            m_Database = databaseName == ":memory:" ? new LiteDatabase(":memory:") : new LiteDatabase($"Filename={databaseName};Password=123");
            m_Donantes = m_Database.GetCollection<Donantes>("donantes");
        }

        public static void Close()
        {
            try
            {
                m_Database.Dispose();

            }
            catch
            {

            }
        }

    }



}