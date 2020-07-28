using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_Ex03_Aviv_315529131_Gal_205431141
{
    public class VehicleParameters
    {
        private string m_ParameterName;
        private Type m_ParameterType;

        public VehicleParameters(string i_ParameterName, Type i_ParameterType)
        {
            m_ParameterName = i_ParameterName;
            m_ParameterType = i_ParameterType;
        }

        public string ParameterName
        {
            get
            {
                return m_ParameterName;
            }
        }

        public Type ParameterType
        {
            get
            {
                return m_ParameterType;
            }
        }
    }
}
