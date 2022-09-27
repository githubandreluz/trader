using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Trader
{
    public static class JSONParser
    {

        /// <summary>
        /// Deserializa o JSON informado no parâmetro <paramref name="json" />
        /// para uma instância de um objeto do tipo especificado em <typeparamref name="TEntity" />
        /// </summary>
        /// <typeparam name="TEntity">Tipo do objeto ao qual o JSON de entrada será convertido</typeparam>
        /// <param name="json">JSON de entrada</param>
        /// <returns>Instância de um objeto do tipo especificado em <typeparamref name="TEntity" /></returns>
        public static TEntity Deserialize<TEntity>(string json) =>
            JsonSerializer.Deserialize<TEntity>(json);

        /// <summary>
        /// Serializa o objeto informado no parâmetro <paramref name="entity" /> em um JSON
        /// </summary>
        /// <typeparam name="TEntity">Tipo do objeto a ser serializado em JSON</typeparam>
        /// <param name="entity">Objeto a ser serializado em JSON</param>
        /// <returns>JSON correspondente ao objeto informado no parâmetro <paramref name="entity" /></returns>
        public static string Serialize<TEntity>(TEntity entity) =>
            JsonSerializer.Serialize(entity, new JsonSerializerOptions { WriteIndented = true });


    }
}
