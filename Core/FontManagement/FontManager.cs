/// File: FontManager.cs
/// Purpose: Defines the methods used to manage current font set and retrive other fonts
/// Version: 1.4
/// Date Modified: 26/2/2021
/// 
/// [CHANGE LOG]
/// [v1.4]
///  - Removed XSerializer references (ISerializer). 
///  - Added Serialization class to serialize and deserialize fonts. 
/// 

/* 
Copyright (c) 2021, All rights are reserved by Zexware, Ltd.

This program is licensed under the Apache License, Version 2.0 (the "License");
you may not download, install or use this program except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
*/
using System.Collections.Generic;

namespace XKeyboard.Core.FontManagement
{
    /// <summary>
    /// Defines the FontManager class used to import, export, configure or modify custom fonts. 
    /// </summary>
    public class FontManager
    {
        #region Private
        private XFont _current_font;
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the current font for the keyboard. Use FontManager.GetFonts() to retrieve available fonts.
        /// </summary>
        public XFont CurrentFont { get { return _current_font; } set { _current_font = value; } }
       
        #endregion
        #region Public Functions
        /// <summary>
        /// Initializes new FontManager class with specified serializer. 
        /// </summary>
        /// <param name="serializer"></param>
        public FontManager()
        {

        }
        /// <summary>
        /// Returns the collection of all available fonts in /Fonts directory.
        /// </summary>
        public List<XFont> GetFonts()
        {
            /////TO-DO/////
            /// Return all available font files in /Fonts
            ///////////////
            //Enumerate all files with .xml extension
            List<XFont> lst = new List<XFont>();
            var dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            dir = dir + "\\Fonts\\";
            if (System.IO.Directory.Exists(dir) == false) return lst;
            foreach (var file in System.IO.Directory.GetFiles(dir, "*.xml", System.IO.SearchOption.TopDirectoryOnly))
            {
                //Try to deserialize file. 
                XFont xf;
                if (Serialization.TryDeserialize(file, out xf))
                {
                    xf.SetFile(file);
                    lst.Add(xf);
                }
                else
                    Logger.Log($"Failed to deserialize: {file}. Ignored. ", MessagePriority.Low, MessageKind.Error);
            }
            return lst;
        }
        #endregion
    }
}
