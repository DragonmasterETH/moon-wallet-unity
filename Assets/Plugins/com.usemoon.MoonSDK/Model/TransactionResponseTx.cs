/*
 * moon-vault-api
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OpenAPIDateConverter = com.usemoon.MoonSDK.Client.OpenAPIDateConverter;

namespace com.usemoon.MoonSDK.Model
{
    /// <summary>
    /// TransactionResponseTx
    /// </summary>
    [DataContract(Name = "TransactionResponse_tx")]
    public partial class TransactionResponseTx : IEquatable<TransactionResponseTx>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionResponseTx" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TransactionResponseTx() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionResponseTx" /> class.
        /// </summary>
        /// <param name="data">data (required).</param>
        /// <param name="value">value (required).</param>
        /// <param name="nonce">nonce (required).</param>
        /// <param name="gas">gas (required).</param>
        /// <param name="to">to (required).</param>
        /// <param name="from">from (required).</param>
        public TransactionResponseTx(string data = default(string), string value = default(string), double nonce = default(double), string gas = default(string), string to = default(string), string from = default(string))
        {
            // to ensure "data" is required (not null)
            if (data == null)
            {
                throw new ArgumentNullException("data is a required property for TransactionResponseTx and cannot be null");
            }
            this.Data = data;
            // to ensure "value" is required (not null)
            if (value == null)
            {
                throw new ArgumentNullException("value is a required property for TransactionResponseTx and cannot be null");
            }
            this.Value = value;
            this.Nonce = nonce;
            // to ensure "gas" is required (not null)
            if (gas == null)
            {
                throw new ArgumentNullException("gas is a required property for TransactionResponseTx and cannot be null");
            }
            this.Gas = gas;
            // to ensure "to" is required (not null)
            if (to == null)
            {
                throw new ArgumentNullException("to is a required property for TransactionResponseTx and cannot be null");
            }
            this.To = to;
            // to ensure "from" is required (not null)
            if (from == null)
            {
                throw new ArgumentNullException("from is a required property for TransactionResponseTx and cannot be null");
            }
            this.From = from;
        }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name = "data", IsRequired = true, EmitDefaultValue = true)]
        public string Data { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name = "value", IsRequired = true, EmitDefaultValue = true)]
        public string Value { get; set; }

        /// <summary>
        /// Gets or Sets Nonce
        /// </summary>
        [DataMember(Name = "nonce", IsRequired = true, EmitDefaultValue = true)]
        public double Nonce { get; set; }

        /// <summary>
        /// Gets or Sets Gas
        /// </summary>
        [DataMember(Name = "gas", IsRequired = true, EmitDefaultValue = true)]
        public string Gas { get; set; }

        /// <summary>
        /// Gets or Sets To
        /// </summary>
        [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = true)]
        public string To { get; set; }

        /// <summary>
        /// Gets or Sets From
        /// </summary>
        [DataMember(Name = "from", IsRequired = true, EmitDefaultValue = true)]
        public string From { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TransactionResponseTx {\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Nonce: ").Append(Nonce).Append("\n");
            sb.Append("  Gas: ").Append(Gas).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as TransactionResponseTx);
        }

        /// <summary>
        /// Returns true if TransactionResponseTx instances are equal
        /// </summary>
        /// <param name="input">Instance of TransactionResponseTx to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransactionResponseTx input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Data == input.Data ||
                    (this.Data != null &&
                    this.Data.Equals(input.Data))
                ) && 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
                ) && 
                (
                    this.Nonce == input.Nonce ||
                    this.Nonce.Equals(input.Nonce)
                ) && 
                (
                    this.Gas == input.Gas ||
                    (this.Gas != null &&
                    this.Gas.Equals(input.Gas))
                ) && 
                (
                    this.To == input.To ||
                    (this.To != null &&
                    this.To.Equals(input.To))
                ) && 
                (
                    this.From == input.From ||
                    (this.From != null &&
                    this.From.Equals(input.From))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Data != null)
                {
                    hashCode = (hashCode * 59) + this.Data.GetHashCode();
                }
                if (this.Value != null)
                {
                    hashCode = (hashCode * 59) + this.Value.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Nonce.GetHashCode();
                if (this.Gas != null)
                {
                    hashCode = (hashCode * 59) + this.Gas.GetHashCode();
                }
                if (this.To != null)
                {
                    hashCode = (hashCode * 59) + this.To.GetHashCode();
                }
                if (this.From != null)
                {
                    hashCode = (hashCode * 59) + this.From.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
