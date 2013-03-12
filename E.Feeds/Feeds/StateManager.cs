using System;
using Microsoft.Phone.Controls;

namespace Feeds
{  
    public static class StateManager
    { 
        public static void SaveState(this PhoneApplicationPage phoneApplicationPage, string key, object value)
        {
            if (phoneApplicationPage.State.ContainsKey(key))
            {
                phoneApplicationPage.State.Remove(key);
            }

            phoneApplicationPage.State.Add(key, value);
        }

         
        public static T LoadState<T>(this PhoneApplicationPage phoneApplicationPage, string key)
            where T : class
        {
            if (phoneApplicationPage.State.ContainsKey(key))
            {
                return (T)phoneApplicationPage.State[key];
            }

            return default(T);
        }
    }
}
