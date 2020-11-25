using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;


namespace BDH.Metadata
{
    public interface IDbDescription
    {
        ValueConverter DataVersionConVerter { get; }
        string DbType { get; }
        string SqlDefault { get; }
    }
}
