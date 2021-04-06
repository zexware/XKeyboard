/// File: Serialization.cs
/// Purpose: Defines the methods used to serialize and deserialize font sets.
/// Version: 1.4
/// Date Modified: 26/2/2021

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
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace XKeyboard.Core
{
    /// <summary>
    /// Provides methods used for XmlSerialization to save and retrieve program data (usually, fonts) 
    /// </summary>
    public class Serialization
    {
        /// <summary>
        /// Attempts to deserialize a XmlDocument and returns true.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static bool TryDeserialize<T>(string file, out T output)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), "XKeyboard");
                var fs = new FileStream(file, FileMode.Open, FileAccess.Read);
                XmlReader reader = XmlReader.Create(fs, new XmlReaderSettings() { CloseInput = true });
                if (xmlSerializer.CanDeserialize(reader))
                {
                    output = (T)xmlSerializer.Deserialize(reader);
                    return true;
                }
                output = default(T);
                return false;
            }
            catch
            {
                output = default(T);
                return false;
            }
        }

        /// <summary>
        /// Serializes the given object using XmlSerializer and saves it in the given location.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="file"></param>
        public static void Serialize<T>(T obj, string file)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), "XKeyboard");
            var fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlWriter writer = XmlWriter.Create(fs, new XmlWriterSettings()
            {
                CloseOutput = true,
                Indent = true,
                WriteEndDocumentOnClose = true,
            });
            xmlSerializer.Serialize(fs, obj);
        }

        /// <summary>
        /// Deserializes a XmlDocument.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string file)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), "XKeyboard");
                var fs = new FileStream(file, FileMode.Open, FileAccess.Read);
                XmlReader reader = XmlReader.Create(fs, new XmlReaderSettings() { CloseInput = true });
                if (xmlSerializer.CanDeserialize(reader))
                {
                    return (T)xmlSerializer.Deserialize(reader);
                }
                return default(T);
            }
            catch
            {
                return default(T);
            }
        }
    }
}
