using System;
using System.Collections.Generic;

namespace CriadorCaes.Models {
 
   /// <summary>
   /// classe usada para transportar os dados necessários 
   /// à correta visualização das fotos dos cães na respetiva interface
   /// </summary>
   public class ListarFotosViewModel {

      /// <summary>
      /// lista das fotografias dos cães
      /// </summary>
      public ICollection<Fotografias> ListaFotos { get; set; }

      /// <summary>
      /// Lista dos IDs dos cães da pessoa que está autenticada
      /// </summary>
      public ICollection<int> ListaCaes { get; set; }
   }
   
   
   
   
   
   public class ErrorViewModel {
      public string RequestId { get; set; }

      public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
   }
}
