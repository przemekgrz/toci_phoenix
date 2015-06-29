﻿using System;

namespace Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator
{
    public interface IDbFieldEntryEntity
    {
        string Name { get; set; } //id

        Type FieldType { get; set; } // int

        // id int primary key

        //constraints, foreign keys
    }
}
