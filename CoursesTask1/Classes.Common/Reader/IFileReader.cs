﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Common.Reader
{
    public interface IFileReader : IReader
    {
        new string Read();
    }
}
