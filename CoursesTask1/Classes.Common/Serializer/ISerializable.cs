﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Common.Serializer
{
    public interface ISerializable<T>
    {
        void Serialize();
        T Deserialize();
    }
}
