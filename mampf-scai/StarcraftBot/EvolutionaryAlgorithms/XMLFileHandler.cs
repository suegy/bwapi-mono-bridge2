using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using StarcraftBot.UnitAgents;

namespace StarcraftBot.EvolutionaryAlgorithms
{
    /// <summary>
    /// This class contains methods for serializing and deserializing the object type UnitAgentOptimizedProperties  to and from an XML file.
    /// Inspiration from: http://www.switchonthecode.com/tutorials/csharp-tutorial-xml-serialization
    /// @author Thomas Willer Sandberg (http://twsandberg.dk/)
    /// @version (1.0, January 2011)
    /// </summary>
    class XmlFileHandler
    {
        //private string Filename;
        public String Filename { get; set; }

        public XmlFileHandler()
        {
           Filename = Settings.Settings.XMLSerializeName;
        }

        public XmlFileHandler(String fileName)
        {
            Filename = fileName;
        }

        public void SerializeToXml(List<UnitAgentOptimizedProperties> unitAgentOpProps)
        {
            var serializer = new XmlSerializer(typeof(List<UnitAgentOptimizedProperties>));
            TextWriter textWriter = new StreamWriter(Filename);//("GAStarCraftUnitAgent.xml");//(@"C:\movie.xml");
            serializer.Serialize(textWriter, unitAgentOpProps);
            textWriter.Close();
        }

        public List<UnitAgentOptimizedProperties> DeserializeFromXml()
        {
            List<UnitAgentOptimizedProperties> unitAgentOpProps = null;

            try
            {
                var deserializer = new XmlSerializer(typeof(List<UnitAgentOptimizedProperties>));
                TextReader textReader = new StreamReader(Filename);
                unitAgentOpProps = (List<UnitAgentOptimizedProperties>)deserializer.Deserialize(textReader);
                textReader.Close();
            }
            catch (Exception e)
            { 
                Logger.Logger.AddAndPrint(e.StackTrace);
            }

            return unitAgentOpProps;
        }
    }
}