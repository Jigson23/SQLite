using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Interop;


namespace HermadosEvangelicos
{
    public interface IConfig
    {
        string DirectorioDB { get; }
        ISQLitePlatform Platform { get; }

    }
}
