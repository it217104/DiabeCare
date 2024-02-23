using System.Xml.Serialization;

namespace DiabeCare.Models
{
    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(Rxnormdata));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (Rxnormdata)serializer.Deserialize(reader);
    // }

    [XmlRoot(ElementName = "conceptGroup")]
    public class ConceptGroup
    {

        [XmlElement(ElementName = "tty")]
        public string Tty { get; set; }

        [XmlElement(ElementName = "conceptProperties")]
        public List<ConceptProperties> ConceptProperties { get; set; }
    }

    [XmlRoot(ElementName = "conceptProperties")]
    public class ConceptProperties
    {

        [XmlElement(ElementName = "rxcui")]
        public int Rxcui { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "synonym")]
        public string Synonym { get; set; }

        [XmlElement(ElementName = "tty")]
        public string Tty { get; set; }

        [XmlElement(ElementName = "language")]
        public string Language { get; set; }

        [XmlElement(ElementName = "suppress")]
        public string Suppress { get; set; }

        [XmlElement(ElementName = "umlscui")]
        public object Umlscui { get; set; }
    }

    [XmlRoot(ElementName = "drugGroup")]
    public class DrugGroup
    {

        [XmlElement(ElementName = "name")]
        public object Name { get; set; }

        [XmlElement(ElementName = "conceptGroup")]
        public List<ConceptGroup> ConceptGroup { get; set; }
    }

    [XmlRoot(ElementName = "rxnormdata")]
    public class Rxnormdata
    {

        [XmlElement(ElementName = "drugGroup")]
        public DrugGroup DrugGroup { get; set; }
    }


}
