using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assets.WebAPI.Controllers
{
    public class GFTCoreController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new[] { "Caring", "Committed", "Courageous", "Collaborative", "Creative" };
        }

        // GET api/values/5
        public Models.CoreValue Get(string id)
        {
            id = id ?? string.Empty;
            id = id.ToLower();
            switch (id)
            {
                case "caring":
                    return new Models.CoreValue
                    {
                        Description = "We care about people, cultures and opinions, and show everyone equal respect.",
                        AlphabetSoup = new Models.Row
                        {
                            Row1 = "U	S	E	N	D	W	X	Z	W	X	I	A	V	E	A".Split(),
                            Row2 = "T	U	J	J	Q	I	P	V	Y	L	M	F	Z	D	M".Split(),
                            Row3 = "H	Z	I	S	O	G	I	N	O	V	M	F	G	I	A".Split(),
                            Row4 = "H	R	K	P	N	J	M	O	P	L	J	Z	C	A	W".Split(),
                            Row5 = "P	S	L	T	C	A	W	E	L	H	U	H	B	Q	K".Split(),
                            Row6 = "Y	H	B	P	M	F	P	P	Y	T	V	Z	L	W	E".Split(),
                            Row7 = "N	L	Q	N	M	J	F	M	P	U	A	V	R	R	K".Split(),
                            Row8 = "O	L	R	J	C	V	A	A	B	K	L	S	F	D	V".Split(),
                            Row9 = "C	P	U	I	A	T	S	C	V	S	P	O	B	L	J".Split(),
                            Row10 = "Q	J	X	X	R	S	S	J	M	A	E	Q	C	F	K".Split(),
                            Row11 = "I	A	H	W	I	H	I	Z	V	V	R	S	C	A	K".Split(),
                            Row12 = "Y	O	H	R	N	O	I	G	D	B	F	Y	V	O	M".Split(),
                            Row13 = "U	E	P	F	G	B	B	Z	L	S	M	M	P	X	V".Split(),
                            Row14 = "L	A	I	R	U	Y	I	E	A	F	R	L	Z	P	S".Split(),
                            Row15 = "S	F	M	Z	P	N	Z	L	D	N	G	H	Z	Z	X".Split('\t')
                        }
                    };
                case "committed":
                    return new Models.CoreValue
                    {
                        Description = "We are committed to our company and our clients.",
                        AlphabetSoup = new Models.Row
                        {
                            Row1 = "U P O S T C M K U D K R O R Y".Split(),
                            Row2 = "T D R K H B O H W E W D D A F".Split(),
                            Row3 = "H D E T T I M M O C L H X A M".Split(),
                            Row4 = "T U K X L D P I U A I P D N N".Split(),
                            Row5 = "U P F M P H I X W X N J W F C".Split(),
                            Row6 = "A J K G Y F O O O Y S D B D Z".Split(),
                            Row7 = "T Q N Y B S B Y O T R E Y V T".Split(),
                            Row8 = "J B L K H T X W D D Z J L S P".Split(),
                            Row9 = "J P V J G X O F M G Q H M K A".Split(),
                            Row10 = "U D K Q Y V B Q O Z W T X Z O".Split(),
                            Row11 = "N Z L P L V W I O E Y K M P H".Split(),
                            Row12 = "A P K W N T R Z D F T B Y F G".Split(),
                            Row13 = "A M P B F C A W E N R B M A D".Split(),
                            Row14 = "U G T X M Q M R R P Q J Q I I".Split(),
                            Row15 = "V U V B W Z W B G Z G O M H W".Split()
                        }
                    };
                case "courageous":
                    return new Models.CoreValue
                    {
                        Description = "We have the courage to challenge and break new ground, thus embracing new growth opportunities.",
                        AlphabetSoup = new Models.Row
                        {
                            Row1 = "Y	W	I	T	H	H	N	V	W	K	Z	W	E	L	R".Split(),
                            Row2 = "W	Z	L	O	U	W	I	S	F	Q	H	P	U	J	Y".Split(),
                            Row3 = "Y	K	S	U	O	E	G	A	R	U	O	C	A	N	P".Split(),
                            Row4 = "B	O	F	G	J	Z	Z	C	G	H	O	K	Q	P	W".Split(),
                            Row5 = "Y	T	X	O	C	I	F	N	A	V	M	H	D	T	M".Split(),
                            Row6 = "W	W	X	D	A	G	E	A	A	T	V	T	H	R	O".Split(),
                            Row7 = "D	Q	M	S	R	Y	V	M	Z	Z	C	Z	U	T	Z".Split(),
                            Row8 = "I	F	I	S	O	B	R	A	C	Q	L	A	D	K	D".Split(),
                            Row9 = "T	E	N	Q	Q	T	P	L	G	I	F	N	L	Y	Z".Split(),
                            Row10 = "J	G	T	Q	O	C	P	A	R	G	H	O	G	V	O".Split(),
                            Row11 = "L	K	I	B	E	Q	Q	T	P	U	E	R	T	O	O".Split(),
                            Row12 = "V	I	X	G	I	N	R	T	M	L	G	S	A	L	L".Split(),
                            Row13 = "R	Y	U	N	O	I	T	Z	D	X	U	T	H	Y	L".Split(),
                            Row14 = "G	G	S	X	L	M	A	X	Y	H	D	J	G	C	W".Split(),
                            Row15 = "P	T	F	B	B	E	F	V	R	S	F	P	M	X	G".Split()
                        }
                    };
                case "collaborative":
                    return new Models.CoreValue
                    {
                        Description = "We collaborate and succeed as one team.",
                        AlphabetSoup = new Models.Row
                        {
                            Row1 = "F	C	O	R	E	S	H	S	T	N	G	Q	P	C	W".Split(),
                            Row2 = "J	X	P	D	A	C	E	I	R	O	F	G	Q	K	D".Split(),
                            Row3 = "S	G	O	F	H	K	R	E	E	A	T	C	S	L	C".Split(),
                            Row4 = "G	J	Q	W	X	B	E	D	Q	C	C	V	L	M	S".Split(),
                            Row5 = "S	V	C	Y	G	Z	D	V	M	R	O	B	K	X	T".Split(),
                            Row6 = "G	J	X	W	C	K	I	T	I	R	O	O	N	K	M".Split(),
                            Row7 = "Y	J	R	P	E	G	A	C	M	U	F	K	M	O	F".Split(),
                            Row8 = "N	F	E	V	I	T	A	R	O	B	A	L	L	O	C".Split(),
                            Row9 = "T	Z	D	R	O	K	E	H	M	R	Z	H	O	S	Q".Split(),
                            Row10 = "L	P	K	Q	U	G	X	A	D	K	O	L	Y	O	G".Split(),
                            Row11 = "X	O	Y	A	C	A	E	Y	V	O	K	V	Y	K	L	".Split(),
                            Row12 = "G	L	N	M	A	I	Q	T	T	A	Z	X	H	N	O".Split(),
                            Row13 = "F	N	L	T	I	I	U	M	G	C	E	Z	A	H	A".Split(),
                            Row14 = "X	M	H	I	Y	Q	N	P	S	L	X	C	J	Z	F".Split(),
                            Row15 = "P	A	Z	E	B	V	U	L	I	R	A	T	S	O	C".Split()
                        }
                    };
                case "creative":
                    return new Models.CoreValue
                    {
                        Description = "We turn ideas into creative solutions and strive for quality in everything we do.",
                        AlphabetSoup = new Models.Row
                        {
                            Row1 = "D	J	S	O	N	E	F	F	L	M	F	P	D	G	B".Split(),
                            Row2 = "O	M	N	H	K	F	M	H	S	I	J	G	C	R	A".Split(),
                            Row3 = "Y	R	F	G	P	U	D	J	J	Q	W	M	S	Z	E".Split(),
                            Row4 = "I	K	A	I	U	S	Z	E	T	Y	K	Z	E	Q	V".Split(),
                            Row5 = "Z	R	B	W	J	R	J	V	E	M	Z	T	C	V	I".Split(),
                            Row6 = "J	U	F	C	P	Q	G	A	N	F	F	O	S	C	T".Split(),
                            Row7 = "U	E	D	P	G	Q	W	U	A	E	U	A	Z	J	A".Split(),
                            Row8 = "O	I	E	W	X	Y	G	A	K	Z	N	X	Q	R	E".Split(),
                            Row9 = "M	L	I	P	Q	O	U	S	I	E	S	Q	Y	J	R".Split(),
                            Row10 = "Y	E	O	U	C	F	A	R	R	W	T	D	A	R	C".Split(),
                            Row11 = "C	C	K	R	G	C	L	A	A	J	S	W	O	T	R".Split(),
                            Row12 = "U	L	P	J	T	H	T	N	M	N	E	R	A	U	V".Split(),
                            Row13 = "G	D	V	E	I	N	T	I	N	U	E	V	E	Z	T".Split(),
                            Row14 = "T	Y	I	Z	U	O	I	I	T	H	J	H	M	Y	Y".Split(),
                            Row15 = "Q	Y	V	P	L	M	Q	L	U	I	E	F	C	Q	Q".Split()
                        }
                    };
                default:
                    return new Models.CoreValue
                    {
                        Description = "Como se hacen los bebes?",
                        AlphabetSoup = new Models.Row
                        {
                            Row1 = "C".Split(),
                            Row2 = "O".Split(),
                            Row3 = "N".Split(),
                            Row4 = "M".Split(),
                            Row5 = "U".Split(),
                            Row6 = "C".Split(),
                            Row7 = "H".Split(),
                            Row8 = "O".Split(),
                            Row9 = "A".Split(),
                            Row10 = "M".Split(),
                            Row11 = "O".Split(),
                            Row12 = "R".Split(),
                            Row13 = "!".Split(),
                            Row14 = "!".Split(),
                            Row15 = "!".Split()
                        }
                    };
            }
        }

        // POST api/values
        public object Post([FromBody]Models.GFTCore value)
        {
            var re = Request;
            var headers = re.Headers.ToList();
            var headerKeys = headers.Select(x => x.Key.ToLower());
            if (headerKeys.Contains("id") && headerKeys.Contains("name") && headerKeys.Contains("lastname"))
            {
                if (value != null && value.Core != null)
                {
                    if (value.Core.Length != 5)
                    {
                        value.Core = value.Core.Select(x => x.ToLower()).ToArray();
                        if (value.Core.Contains("caring") && value.Core.Contains("collaborative") && value.Core.Contains("creative")
                            && value.Core.Contains("courageous") && value.Core.Contains("committed"))
                        {
                            return new
                            {
                                Status = "Ok",
                                Message = "Prueba completada"
                            };
                        }
                        else
                        {
                            return new
                            {
                                Status = "Error",
                                Message = "No son los 5 correctos"
                            };
                        }
                    }
                    else
                    {
                        return new
                        {
                            Status = "Error",
                            Message = "Son 5 core values"
                        };
                    }
                }
                else
                {
                    return new
                    {
                        Status = "Error",
                        Message = "Sigue intentando"
                    };
                }
            }
            else
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(responseMessage);
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}