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
    /// INFTApproval
    /// </summary>
    [DataContract(Name = "INFTApproval")]
    public partial class INFTApproval : IEquatable<INFTApproval>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="INFTApproval" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected INFTApproval() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="INFTApproval" /> class.
        /// </summary>
        /// <param name="transactionHash">transactionHash (required).</param>
        /// <param name="contract">contract (required).</param>
        /// <param name="logIndex">logIndex (required).</param>
        /// <param name="tokenContractType">tokenContractType (required).</param>
        /// <param name="tokenName">tokenName (required).</param>
        /// <param name="tokenSymbol">tokenSymbol (required).</param>
        /// <param name="account">account (required).</param>
        /// <param name="varOperator">varOperator (required).</param>
        /// <param name="approvedAll">approvedAll (required).</param>
        /// <param name="tokenId">tokenId (required).</param>
        public INFTApproval(string transactionHash = default(string), string contract = default(string), string logIndex = default(string), string tokenContractType = default(string), string tokenName = default(string), string tokenSymbol = default(string), string account = default(string), string varOperator = default(string), bool approvedAll = default(bool), string tokenId = default(string))
        {
            // to ensure "transactionHash" is required (not null)
            if (transactionHash == null)
            {
                throw new ArgumentNullException("transactionHash is a required property for INFTApproval and cannot be null");
            }
            this.TransactionHash = transactionHash;
            // to ensure "contract" is required (not null)
            if (contract == null)
            {
                throw new ArgumentNullException("contract is a required property for INFTApproval and cannot be null");
            }
            this.Contract = contract;
            // to ensure "logIndex" is required (not null)
            if (logIndex == null)
            {
                throw new ArgumentNullException("logIndex is a required property for INFTApproval and cannot be null");
            }
            this.LogIndex = logIndex;
            // to ensure "tokenContractType" is required (not null)
            if (tokenContractType == null)
            {
                throw new ArgumentNullException("tokenContractType is a required property for INFTApproval and cannot be null");
            }
            this.TokenContractType = tokenContractType;
            // to ensure "tokenName" is required (not null)
            if (tokenName == null)
            {
                throw new ArgumentNullException("tokenName is a required property for INFTApproval and cannot be null");
            }
            this.TokenName = tokenName;
            // to ensure "tokenSymbol" is required (not null)
            if (tokenSymbol == null)
            {
                throw new ArgumentNullException("tokenSymbol is a required property for INFTApproval and cannot be null");
            }
            this.TokenSymbol = tokenSymbol;
            // to ensure "account" is required (not null)
            if (account == null)
            {
                throw new ArgumentNullException("account is a required property for INFTApproval and cannot be null");
            }
            this.Account = account;
            // to ensure "varOperator" is required (not null)
            if (varOperator == null)
            {
                throw new ArgumentNullException("varOperator is a required property for INFTApproval and cannot be null");
            }
            this.VarOperator = varOperator;
            this.ApprovedAll = approvedAll;
            // to ensure "tokenId" is required (not null)
            if (tokenId == null)
            {
                throw new ArgumentNullException("tokenId is a required property for INFTApproval and cannot be null");
            }
            this.TokenId = tokenId;
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
        /// Gets or Sets TokenContractType
        /// </summary>
        [DataMember(Name = "tokenContractType", IsRequired = true, EmitDefaultValue = true)]
        public string TokenContractType { get; set; }

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
        /// Gets or Sets Account
        /// </summary>
        [DataMember(Name = "account", IsRequired = true, EmitDefaultValue = true)]
        public string Account { get; set; }

        /// <summary>
        /// Gets or Sets VarOperator
        /// </summary>
        [DataMember(Name = "operator", IsRequired = true, EmitDefaultValue = true)]
        public string VarOperator { get; set; }

        /// <summary>
        /// Gets or Sets ApprovedAll
        /// </summary>
        [DataMember(Name = "approvedAll", IsRequired = true, EmitDefaultValue = true)]
        public bool ApprovedAll { get; set; }

        /// <summary>
        /// Gets or Sets TokenId
        /// </summary>
        [DataMember(Name = "tokenId", IsRequired = true, EmitDefaultValue = true)]
        public string TokenId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class INFTApproval {\n");
            sb.Append("  TransactionHash: ").Append(TransactionHash).Append("\n");
            sb.Append("  Contract: ").Append(Contract).Append("\n");
            sb.Append("  LogIndex: ").Append(LogIndex).Append("\n");
            sb.Append("  TokenContractType: ").Append(TokenContractType).Append("\n");
            sb.Append("  TokenName: ").Append(TokenName).Append("\n");
            sb.Append("  TokenSymbol: ").Append(TokenSymbol).Append("\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
            sb.Append("  VarOperator: ").Append(VarOperator).Append("\n");
            sb.Append("  ApprovedAll: ").Append(ApprovedAll).Append("\n");
            sb.Append("  TokenId: ").Append(TokenId).Append("\n");
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
            return this.Equals(input as INFTApproval);
        }

        /// <summary>
        /// Returns true if INFTApproval instances are equal
        /// </summary>
        /// <param name="input">Instance of INFTApproval to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(INFTApproval input)
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
                    this.TokenContractType == input.TokenContractType ||
                    (this.TokenContractType != null &&
                    this.TokenContractType.Equals(input.TokenContractType))
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
                    this.Account == input.Account ||
                    (this.Account != null &&
                    this.Account.Equals(input.Account))
                ) && 
                (
                    this.VarOperator == input.VarOperator ||
                    (this.VarOperator != null &&
                    this.VarOperator.Equals(input.VarOperator))
                ) && 
                (
                    this.ApprovedAll == input.ApprovedAll ||
                    this.ApprovedAll.Equals(input.ApprovedAll)
                ) && 
                (
                    this.TokenId == input.TokenId ||
                    (this.TokenId != null &&
                    this.TokenId.Equals(input.TokenId))
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
                if (this.TokenContractType != null)
                {
                    hashCode = (hashCode * 59) + this.TokenContractType.GetHashCode();
                }
                if (this.TokenName != null)
                {
                    hashCode = (hashCode * 59) + this.TokenName.GetHashCode();
                }
                if (this.TokenSymbol != null)
                {
                    hashCode = (hashCode * 59) + this.TokenSymbol.GetHashCode();
                }
                if (this.Account != null)
                {
                    hashCode = (hashCode * 59) + this.Account.GetHashCode();
                }
                if (this.VarOperator != null)
                {
                    hashCode = (hashCode * 59) + this.VarOperator.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ApprovedAll.GetHashCode();
                if (this.TokenId != null)
                {
                    hashCode = (hashCode * 59) + this.TokenId.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
