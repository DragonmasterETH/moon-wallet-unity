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
    /// IERC20Transfer
    /// </summary>
    [DataContract(Name = "IERC20Transfer")]
    public partial class IERC20Transfer : IEquatable<IERC20Transfer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IERC20Transfer" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected IERC20Transfer() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="IERC20Transfer" /> class.
        /// </summary>
        /// <param name="transactionHash">transactionHash (required).</param>
        /// <param name="contract">contract (required).</param>
        /// <param name="logIndex">logIndex (required).</param>
        /// <param name="from">from (required).</param>
        /// <param name="to">to (required).</param>
        /// <param name="value">value (required).</param>
        /// <param name="tokenDecimals">tokenDecimals (required).</param>
        /// <param name="tokenName">tokenName (required).</param>
        /// <param name="tokenSymbol">tokenSymbol (required).</param>
        /// <param name="valueWithDecimals">valueWithDecimals.</param>
        /// <param name="triggers">triggers.</param>
        public IERC20Transfer(string transactionHash = default(string), string contract = default(string), string logIndex = default(string), string from = default(string), string to = default(string), string value = default(string), string tokenDecimals = default(string), string tokenName = default(string), string tokenSymbol = default(string), string valueWithDecimals = default(string), List<TriggerOutput> triggers = default(List<TriggerOutput>))
        {
            // to ensure "transactionHash" is required (not null)
            if (transactionHash == null)
            {
                throw new ArgumentNullException("transactionHash is a required property for IERC20Transfer and cannot be null");
            }
            this.TransactionHash = transactionHash;
            // to ensure "contract" is required (not null)
            if (contract == null)
            {
                throw new ArgumentNullException("contract is a required property for IERC20Transfer and cannot be null");
            }
            this.Contract = contract;
            // to ensure "logIndex" is required (not null)
            if (logIndex == null)
            {
                throw new ArgumentNullException("logIndex is a required property for IERC20Transfer and cannot be null");
            }
            this.LogIndex = logIndex;
            // to ensure "from" is required (not null)
            if (from == null)
            {
                throw new ArgumentNullException("from is a required property for IERC20Transfer and cannot be null");
            }
            this.From = from;
            // to ensure "to" is required (not null)
            if (to == null)
            {
                throw new ArgumentNullException("to is a required property for IERC20Transfer and cannot be null");
            }
            this.To = to;
            // to ensure "value" is required (not null)
            if (value == null)
            {
                throw new ArgumentNullException("value is a required property for IERC20Transfer and cannot be null");
            }
            this.Value = value;
            // to ensure "tokenDecimals" is required (not null)
            if (tokenDecimals == null)
            {
                throw new ArgumentNullException("tokenDecimals is a required property for IERC20Transfer and cannot be null");
            }
            this.TokenDecimals = tokenDecimals;
            // to ensure "tokenName" is required (not null)
            if (tokenName == null)
            {
                throw new ArgumentNullException("tokenName is a required property for IERC20Transfer and cannot be null");
            }
            this.TokenName = tokenName;
            // to ensure "tokenSymbol" is required (not null)
            if (tokenSymbol == null)
            {
                throw new ArgumentNullException("tokenSymbol is a required property for IERC20Transfer and cannot be null");
            }
            this.TokenSymbol = tokenSymbol;
            this.ValueWithDecimals = valueWithDecimals;
            this.Triggers = triggers;
        }

        /// <summary>
        /// Gets or Sets TransactionHash
        /// </summary>
        [DataMember(Name = "transactionHash", IsRequired = true, EmitDefaultValue = true)]
        public string TransactionHash { get; set; }

        /// <summary>
        /// Gets or Sets Contract
        /// </summary>
        [DataMember(Name = "contract", IsRequired = true, EmitDefaultValue = true)]
        public string Contract { get; set; }

        /// <summary>
        /// Gets or Sets LogIndex
        /// </summary>
        [DataMember(Name = "logIndex", IsRequired = true, EmitDefaultValue = true)]
        public string LogIndex { get; set; }

        /// <summary>
        /// Gets or Sets From
        /// </summary>
        [DataMember(Name = "from", IsRequired = true, EmitDefaultValue = true)]
        public string From { get; set; }

        /// <summary>
        /// Gets or Sets To
        /// </summary>
        [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = true)]
        public string To { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name = "value", IsRequired = true, EmitDefaultValue = true)]
        public string Value { get; set; }

        /// <summary>
        /// Gets or Sets TokenDecimals
        /// </summary>
        [DataMember(Name = "tokenDecimals", IsRequired = true, EmitDefaultValue = true)]
        public string TokenDecimals { get; set; }

        /// <summary>
        /// Gets or Sets TokenName
        /// </summary>
        [DataMember(Name = "tokenName", IsRequired = true, EmitDefaultValue = true)]
        public string TokenName { get; set; }

        /// <summary>
        /// Gets or Sets TokenSymbol
        /// </summary>
        [DataMember(Name = "tokenSymbol", IsRequired = true, EmitDefaultValue = true)]
        public string TokenSymbol { get; set; }

        /// <summary>
        /// Gets or Sets ValueWithDecimals
        /// </summary>
        [DataMember(Name = "valueWithDecimals", EmitDefaultValue = false)]
        public string ValueWithDecimals { get; set; }

        /// <summary>
        /// Gets or Sets Triggers
        /// </summary>
        [DataMember(Name = "triggers", EmitDefaultValue = false)]
        public List<TriggerOutput> Triggers { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class IERC20Transfer {\n");
            sb.Append("  TransactionHash: ").Append(TransactionHash).Append("\n");
            sb.Append("  Contract: ").Append(Contract).Append("\n");
            sb.Append("  LogIndex: ").Append(LogIndex).Append("\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  TokenDecimals: ").Append(TokenDecimals).Append("\n");
            sb.Append("  TokenName: ").Append(TokenName).Append("\n");
            sb.Append("  TokenSymbol: ").Append(TokenSymbol).Append("\n");
            sb.Append("  ValueWithDecimals: ").Append(ValueWithDecimals).Append("\n");
            sb.Append("  Triggers: ").Append(Triggers).Append("\n");
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
            return this.Equals(input as IERC20Transfer);
        }

        /// <summary>
        /// Returns true if IERC20Transfer instances are equal
        /// </summary>
        /// <param name="input">Instance of IERC20Transfer to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IERC20Transfer input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.TransactionHash == input.TransactionHash ||
                    (this.TransactionHash != null &&
                    this.TransactionHash.Equals(input.TransactionHash))
                ) && 
                (
                    this.Contract == input.Contract ||
                    (this.Contract != null &&
                    this.Contract.Equals(input.Contract))
                ) && 
                (
                    this.LogIndex == input.LogIndex ||
                    (this.LogIndex != null &&
                    this.LogIndex.Equals(input.LogIndex))
                ) && 
                (
                    this.From == input.From ||
                    (this.From != null &&
                    this.From.Equals(input.From))
                ) && 
                (
                    this.To == input.To ||
                    (this.To != null &&
                    this.To.Equals(input.To))
                ) && 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
                ) && 
                (
                    this.TokenDecimals == input.TokenDecimals ||
                    (this.TokenDecimals != null &&
                    this.TokenDecimals.Equals(input.TokenDecimals))
                ) && 
                (
                    this.TokenName == input.TokenName ||
                    (this.TokenName != null &&
                    this.TokenName.Equals(input.TokenName))
                ) && 
                (
                    this.TokenSymbol == input.TokenSymbol ||
                    (this.TokenSymbol != null &&
                    this.TokenSymbol.Equals(input.TokenSymbol))
                ) && 
                (
                    this.ValueWithDecimals == input.ValueWithDecimals ||
                    (this.ValueWithDecimals != null &&
                    this.ValueWithDecimals.Equals(input.ValueWithDecimals))
                ) && 
                (
                    this.Triggers == input.Triggers ||
                    this.Triggers != null &&
                    input.Triggers != null &&
                    this.Triggers.SequenceEqual(input.Triggers)
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
                if (this.TransactionHash != null)
                {
                    hashCode = (hashCode * 59) + this.TransactionHash.GetHashCode();
                }
                if (this.Contract != null)
                {
                    hashCode = (hashCode * 59) + this.Contract.GetHashCode();
                }
                if (this.LogIndex != null)
                {
                    hashCode = (hashCode * 59) + this.LogIndex.GetHashCode();
                }
                if (this.From != null)
                {
                    hashCode = (hashCode * 59) + this.From.GetHashCode();
                }
                if (this.To != null)
                {
                    hashCode = (hashCode * 59) + this.To.GetHashCode();
                }
                if (this.Value != null)
                {
                    hashCode = (hashCode * 59) + this.Value.GetHashCode();
                }
                if (this.TokenDecimals != null)
                {
                    hashCode = (hashCode * 59) + this.TokenDecimals.GetHashCode();
                }
                if (this.TokenName != null)
                {
                    hashCode = (hashCode * 59) + this.TokenName.GetHashCode();
                }
                if (this.TokenSymbol != null)
                {
                    hashCode = (hashCode * 59) + this.TokenSymbol.GetHashCode();
                }
                if (this.ValueWithDecimals != null)
                {
                    hashCode = (hashCode * 59) + this.ValueWithDecimals.GetHashCode();
                }
                if (this.Triggers != null)
                {
                    hashCode = (hashCode * 59) + this.Triggers.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
