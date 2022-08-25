using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Example.NetCore.DataAccess.Models
{
    public class Result<T>
    {
        public int CodeResult { get; set; }

        public int CodeDataBase { get; set; }

        public bool IsSuccess { get; set; }

        public IEnumerable<string> Details { get; set; }

        public string Message { get; set; }

        public T Element { get; set; }

        public IEnumerable<T> List { get; set; }

        public Result()
        {
            this.CodeResult = (int)System.Net.HttpStatusCode.InternalServerError;
            this.IsSuccess = false;
            this.Message = "Ocurrió un error al realizar la operación indicada";
            this.Details = new List<string>();
        }

        /// <summary>
        /// Assigns the properties set for a successful query
        /// </summary>
        /// <typeparam name="T">Generic object to be returned as a list or element</typeparam>
        public void ConsultaCorrecta()
        {
            this.IsSuccess = true;
            this.CodeResult = (int)System.Net.HttpStatusCode.OK;
            this.Message = "Consulta realizada correctamente";
        }

        public void ConsultaNoEncontrada()
        {
            this.IsSuccess = true;
            this.CodeResult = (int)System.Net.HttpStatusCode.NotFound;
            this.Message = "No se encontraron resultados con la consulta solicitada";
        }

        /// <summary>
        /// Assign default properties for a build
        /// </summary>
        /// <typeparam name="T">Generic object to be returned as a list or element</typeparam>
        public void CreacionCorrecta()
        {
            this.IsSuccess = true;
            this.CodeResult = (int)System.Net.HttpStatusCode.Created;
            this.Message = "Información almacenada exitosamente";
        }

        /// <summary>
        /// Assign default properties for a delete
        /// </summary>
        /// <typeparam name="T">Generic object to be returned as a list or element</typeparam>
        public void EliminacionCorrecta()
        {
            this.IsSuccess = true;
            this.CodeResult = (int)System.Net.HttpStatusCode.OK;
            this.Message = "Información eliminada exitosamente";
        }

        /// <summary>
        /// Assign default properties for a successful update
        /// </summary>
        /// <typeparam name="T">Generic object to be returned as a list or element</typeparam>
        public void ActualizacionCorrecta()
        {
            this.IsSuccess = true;
            this.CodeResult = (int)System.Net.HttpStatusCode.OK;
            this.Message = "Información actualizada exitosamente";
        }

        /// <summary>
        /// Assign default properties when an error is generated
        /// </summary>
        /// <param name="errorCode">Error code that the api will return</param>
        /// <param name="message">Error message text</param>
        /// <param name="details">List of details to show</param>
        public void Error(int errorCode, string message, IEnumerable<string> details)
        {
            this.IsSuccess = false;
            this.CodeResult = errorCode;
            this.Message = message;
            this.Details = details;
            this.Element = default(T);
            this.List = null;
        }
    }
}
