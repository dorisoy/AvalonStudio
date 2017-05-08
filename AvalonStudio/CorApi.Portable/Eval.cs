﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CorApi.Portable
{
    public partial class Eval
    {
        public void NewParameterizedArray(Type type, int rank, int dims, int lowBounds)
        {
            var eval2 = QueryInterface<Eval2>();
            eval2.NewParameterizedArray(type, rank, dims, lowBounds);
        }

        public void NewParameterizedObject(Function managedFunction, Type[] argumentTypes, Value[] arguments)
        {

            Type[] types = null;
            int typesLength = 0;
            Value[] values = null;
            int valuesLength = 0;
            var eval2 = QueryInterfaceOrNull<Eval2>();

            if (argumentTypes != null)
            {
                types = new Type[argumentTypes.Length];
                for (int i = 0; i < argumentTypes.Length; i++)
                    types[i] = argumentTypes[i];
                typesLength = types.Length;
            }
            if (arguments != null)
            {
                values = new Value[arguments.Length];
                for (int i = 0; i < arguments.Length; i++)
                    values[i] = arguments[i];
                valuesLength = values.Length;
            }

            eval2.NewParameterizedObject(managedFunction, typesLength, types, valuesLength, values);
        }

        public void CallParameterizedFunction(Function managedFunction, Type[] argumentTypes, Value[] arguments)
        {
            Type[] types = null;
            int typesLength = 0;
            Value[] values = null;
            int valuesLength = 0;

            var eval2 = QueryInterfaceOrNull<Eval2>();

            if (argumentTypes != null)
            {
                types = new Type[argumentTypes.Length];
                for (int i = 0; i < argumentTypes.Length; i++)
                    types[i] = argumentTypes[i];
                typesLength = types.Length;
            }
            if (arguments != null)
            {
                values = new Value[arguments.Length];
                for (int i = 0; i < arguments.Length; i++)
                    values[i] = arguments[i];
                valuesLength = values.Length;
            }
            eval2.CallParameterizedFunction(managedFunction, typesLength, types, valuesLength, values);
        }


        /** Rude abort the current computation. */
        public void RudeAbort()
        {
            QueryInterface<Eval2>().RudeAbort();
        }

        public Value CreateValueForType(Type type)
        {
            Value val = null;
            var eval2 = QueryInterface<Eval2>();
            eval2.CreateValueForType(type, out val);
            return val;
        }
    }
}
