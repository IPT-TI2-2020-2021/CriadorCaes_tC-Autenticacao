using System;
using System.Collections.Generic;

namespace CriadorCaes.Models {
 
   /// <summary>
   /// classe usada para transportar os dados necess�rios 
   /// � correta visualiza��o das fotos dos c�es na respetiva interface
   /// </summary>
   public class ListarFotosViewModel {

      /// <summary>
      /// lista das fotografias dos c�es
      /// </summary>
      public ICollection<Fotografias> ListaFotos { get; set; }

      /// <summary>
      /// Lista dos IDs dos c�es da pessoa que est� autenticada
      /// </summary>
      public ICollection<int> ListaCaes { get; set; }
   }
   
   
   
   
   
   public class ErrorViewModel {
      public string RequestId { get; set; }

      public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
   }
}
