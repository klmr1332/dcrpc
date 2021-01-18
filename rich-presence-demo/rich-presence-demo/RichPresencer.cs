using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ez kell, mivel c++ -os a rich presence dll
using System.Runtime.InteropServices;

namespace rich_presence_demo
{
    class RichPresencer
    {
        [DllImport("presence.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Initialize")]
        public static extern void Initialize(string applicationId, ref RichPresencer.ehandler handlers, bool autoRegister, string optionalSteamId);


        [DllImport("presence.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_RunCallbacks")]
        public static extern void RunCallbacks();


        [DllImport("presence.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Shutdown")]
        public static extern void Shutdown();


        [DllImport("presence.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UpdatePresence")]
        public static extern void UpdatePresence(ref RichPresencer.prsnc presence);

        internal static void Initialize(string v1, ref object handlers, bool v2, object p)
        {
            throw new NotImplementedException();
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void DisconnectedCallback(int errorCode, string message);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ErrorCallback(int errorCode, string message);


        public struct ehandler
        {

            public RichPresencer.ReadyCallback readyCallback;


            public RichPresencer.DisconnectedCallback disconnectedCallback;


            public RichPresencer.ErrorCallback errorCallback;
        }


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ReadyCallback();


        [Serializable]
        public struct prsnc
        {

            public string state; 
            public string details;
            public long start; // timestamp
            public long end; // timestamp
            public string largeImageKey; // A developer oldalon megadott képnek a kulcsával tudsz hivatkozni PL: feltöltök egy képet asd néven akkor asd-vel hivatkozok.
            public string largeImageText; // onHover effekt - Mit jelentítsen meg ha valaki ráviszi a kurzort.
            public string smallImageKey; // /|\
            public string smallImageText; // |
            public string partyId;
            public int partySize;
            public int partyMax;
            public string matchSecret; //Játék fejlesztéskor létrehozható custom join kulcs - általában base64 dekód -
            public string joinSecret; // --||--
            public string spectateSecret; // --||--
            public bool instance; 
        }
    }
}
