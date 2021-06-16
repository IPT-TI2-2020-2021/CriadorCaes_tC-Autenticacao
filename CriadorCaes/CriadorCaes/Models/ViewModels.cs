using System;
using System.Collections.Generic;

namespace CriadorCaes.Models {
 
   /// <summary>
   /// view model para transportar os dados dos cães
   /// para a API
   /// </summary>
   public class ListaCaesApiViewModel {

      /// <summary>
      /// id do Cão
      /// </summary>
      public int IdCao { get; set; }
      
      /// <summary>
      /// nome do Cão
      /// </summary>
      public string NomeCao { get; set; }
   }

   /// <summary>
   /// view model para transportar os dados pesquisados, dentro da API
   /// </summary>
   public class ListaFotosApiViewModel {

      /// <summary>
      /// identificador da fotografia
      /// </summary>
      public int IdFoto { get; set; }

      /// <summary>
      /// nome do ficheiro com a foto
      /// </summary>
      public string NomeFoto { get; set; }

      /// <summary>
      /// data da fotografia
      /// </summary>
      public string DataFoto { get; set; }

      /// <summary>
      /// nome do local onde a foto foi obtida
      /// </summary>
      public string LocalFoto { get; set; }

      /// <summary>
      /// nome do Cão
      /// </summary>
      public string NomeCao { get; set; }

   }



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
