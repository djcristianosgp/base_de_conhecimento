///////////Percorrer HTML para  achar uma chave específica
 public static string ConvertHSLToHex(string html)
 {
     HtmlDocument doc = new HtmlDocument();
     try
     {
         doc.LoadHtml(html);

         // Encontra todos os elementos com o atributo de estilo contendo HSL
         var elementsWithHSL = doc.DocumentNode.SelectNodes("//*[contains(@style,'hsl')]");

         if (elementsWithHSL != null)
         {
             foreach (var element in elementsWithHSL)
             {
                 // Obtém o valor do atributo de estilo
                 var styleAttribute = element.Attributes["style"].Value;

                 // Substitui todas as ocorrências de HSL por hexadecimal
                 string convertedStyle = styleAttribute.Replace("color:hsl", "")
                     .Replace("(", "")
                     .Replace("%", "")
                     .Replace(")", "")
                     .Replace(" ", "")
                     .Replace(";", "");

                 var hhhhhh = Convert.ToInt32(convertedStyle.Split(',')[0].Trim());
                 var ssssss = Convert.ToInt32(convertedStyle.Split(',')[1].Trim());
                 var llllll = Convert.ToInt32(convertedStyle.Split(',')[2].Trim());
                 var cooo = new HSL(hhhhhh, ssssss, llllll,0);
                 var colorConvert = HSLToRGB(cooo);

                 // Atualiza o valor do atributo de estilo
                 element.Attributes["style"].Value = $"color:rgb({colorConvert.R},{colorConvert.G},{colorConvert.B});";
             }
         }

         // Retorna o HTML modificado
         return doc.DocumentNode.OuterHtml;
     }
     catch (Exception ex)
     {
         return html;
     }
 }
