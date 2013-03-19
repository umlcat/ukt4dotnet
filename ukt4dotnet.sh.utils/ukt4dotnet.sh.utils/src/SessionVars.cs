using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace romo.shared.utilities
{
    /// <summary>
    /// Emula sesiones para "WinForms", de forma similar a "ASP.Net" .
    /// </summary>
    public static class SessionsVars
    {
        // lista de datos llave-valor
        private static Hashtable _SessionVars = new Hashtable();

        public static bool isRegistered(String Key)
        {
            bool Result = false;

            Result = _SessionVars.ContainsKey(Key);

            return Result;
        }

        public static void register(String Key, Object Value)
        {
            // delete previous value, if exists
            if (isRegistered(Key))
            {
                _SessionVars.Remove(Key);
            }
            // add the same key, with a new value, as a new item
            _SessionVars.Add(Key, Value);
        }

        public static void unregister(String Key, Object Value)
        {
            // if the key exists, delete the item
            if (isRegistered(Key))
            {
                _SessionVars.Remove(Key);
            }
        }

        public static object ValueByKey(String Key)
        {
            object Result = null;

            if (isRegistered(Key))
            {
                Result = _SessionVars[Key];
            }

            return Result;
        }
    } // static class SessionsVars

} // namespace
