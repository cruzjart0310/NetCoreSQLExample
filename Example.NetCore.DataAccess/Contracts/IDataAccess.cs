using Example.NetCore.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.NetCore.DataAccess.Contracts
{
    public interface IDataAccess
    {
        /// <summary>
        /// Add the connection string to the Database
        /// </summary>
        void ConnectionString(string connectionString);
        /// <summary>
        /// Indica si los Stored procedure utilizan los parámetros predefinidos NRESULTADO y VMENSAJE_RESULTADO
        /// </summary>
        void DefaultParameters(bool defaultParameters);
        /// <summary>
        /// Indica el Stored procedure que será ejecutado
        /// </summary>
        void StoredProcedure(string storedProcedure);
        /// <summary>
        /// Agrega un parámetro de tipo int a la lista de parámetros
        /// </summary>
        void AddParameter(string name, int value);
        /// <summary>
        /// Agrega un parámetro de tipo long a la lista de parámetros
        /// </summary>
        void AddParameter(string name, long value);
        /// <summary>
        /// Agrega un parámetro de tipo double a la lista de parámetros
        /// </summary>
        void AddParameter(string name, double value);
        /// <summary>
        /// Agrega un parámetro de tipo string a la lista de parámetros
        /// </summary>
        void AddParameter(string name, string value);
        /// <summary>
        /// Agrega un parámetro de tipo bool a la lista de parámetros
        /// </summary>
        void AddParameter(string name, bool value);
        /// <summary>
        /// Agrega un parámetro de tipo bool? a la lista de parámetros
        /// </summary>
        void AddParameter(string name, bool? value);
        /// <summary>
        /// Agrega un parámetro de tipo decimal a la lista de parámetros
        /// </summary>
        void AddParameter(string name, decimal value);
        /// <summary>
        /// Agrega un parámetro de tipo DateTime? a la lista de parámetros
        /// </summary>
        void AddParameter(string name, DateTime? value);
        /// <summary>
        /// Agrega un parámetro de tipo byte[] a la lista de parámetros
        /// </summary>
        void AddParameter(string name, byte[] value);
        /// <summary>
        /// Agrega un parámetro de User type a la lista de parámetros
        /// </summary>
        void AddParameter(string name, string type, DataTable value);
        /// <summary>
        /// Ejecuta el Stored procedure indicado sin recuperar datos
        /// </summary>
        Result<T> SetData<T>();
        /// <summary>
        /// Ejecuta el Stored procedure indicado y recupera el resultado en forma de lista
        /// </summary>
        Result<T> ReadData<T>();
        /// <summary>
        /// Ejecuta el Stored procedure indicado y recupera el primer elemento del resultado
        /// </summary>
        Task<Result<T>> ReadSingle<T>();
        /// <summary>
        /// Ejecuta el Script indicado y recupera el primer elemento del resultado
        /// </summary>
        Result<T> ReadScalar<T>(string Script);
        /// <summary>
        /// Ejecuta el Script indicado y recupera el resultado en forma de lista
        /// </summary>
        Result<T> ReadFromScript<T>(string Script);
    }
}
