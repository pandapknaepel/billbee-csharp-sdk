﻿using Panda.NuGet.BillbeeClient.Enums;

namespace Panda.NuGet.BillbeeClient.Models
{
    public class Order
    {
        /// <summary>
        /// List of ids, that reference to the shippings, that have been made for this order.
        /// </summary>
        public List<OrderShippingId>? ShippingIds { get; set; }

        /// <summary>
        /// Kunde hat Verlust des Widerrufrechts akzeptiert OR Customer accepts loss due to withdrawal
        /// </summary>
        public bool AcceptLossOfReturnRight { get; set; }

        /// <summary>
        /// Id of the order in the external system (marketplace)
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Ordernumber of the order in the external system (marketplace)
        /// </summary>
        /// <remarks>Is often the same as the id</remarks>
        public string? OrderNumber { get; set; }

        /// <summary>
        /// The state, the order is currently in
        /// </summary>
        public OrderStateEnum State { get; set; }

        /// <summary>
        /// The vat mode, this order was created with.
        /// </summary>
        public VatModeEnum? VatMode { get; set; }

        /// <summary>
        /// The timestamp, this order was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The timestamp, this order was shipped
        /// </summary>
        public DateTime? ShippedAt { get; set; }

        /// <summary>
        /// The timestamp, this order was confirmed and accepted.
        /// </summary>
        public DateTime? ConfirmedAt { get; set; }

        /// <summary>
        /// The timestamp, this order was payed at.
        /// </summary>
        public DateTime? PayedAt { get; set; }

        /// <summary>
        /// Internal comment to this order
        /// </summary>
        public string? SellerComment { get; set; }

        /// <summary>
        /// Comments and messages between customer and shop owner
        /// </summary>
        public List<Comment>? Comments { get; set; }

        /// <summary>
        /// Prefix used, to create the invoice number
        /// </summary>
        public string? InvoiceNumberPrefix { get; set; }

        /// <summary>
        /// Postfix used, to create the invoice number
        /// </summary>
        public string? InvoiceNumberPostfix { get; set; }

        /// <summary>
        /// Auto generated number, to build the invoice number.
        /// <see cref="InvoiceNumberPrefix"/><see cref="InvoiceNumber"/><see cref="InvoiceNumberPostfix"/>
        /// </summary>
        public int? InvoiceNumber { get; set; }

        /// <summary>
        /// The date of the invoice.
        /// </summary>
        public DateTime? InvoiceDate { get; set; }

        /// <summary>
        /// Addressee of the invoice
        /// </summary>
        public Address? InvoiceAddress { get; set; }

        /// <summary>
        /// Addressee, where the order was/is shipped to
        /// </summary>
        public Address? ShippingAddress { get; set; }

        /// <summary>
        /// The payment method, used to pay this order
        /// </summary>
        public PaymentTypeEnum PaymentMethod { get; set; }

        /// <summary>
        /// The cost, that was defined for shipping in this order.
        /// </summary>
        public decimal ShippingCost { get; set; }

        /// <summary>
        /// Total gross value of the order
        /// </summary>
        public decimal TotalCost { get; set; }

        /// <summary>
        /// The list of items purchased like shirt , pant , toys etc
        /// </summary>
        public List<OrderItem>? OrderItems { get; set; }

        public string? Currency { get; set; }
        public OrderUser? Seller { get; set; }
        public OrderUser? Buyer { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public decimal? TaxRate1 { get; set; }
        public decimal? TaxRate2 { get; set; }

        /// <summary>
        /// The Order.Id from the Billbee database if available in the external system
        /// </summary>
        public long? BillBeeOrderId { get; set; }

        public long? BillBeeParentOrderId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string? VatId { get; set; }

        /// <summary>
        /// List of individual tags, that are appended to this order.
        /// </summary>
        public List<string>? Tags { get; set; }


        public decimal? ShipWeightKg { get; set; }

        /// <summary>
        /// Code of the language, this order was created in
        /// </summary>
        public string? LanguageCode { get; set; }

        /// <summary>
        /// Total amount paid by the customer for this order.
        /// </summary>
        public decimal? PaidAmount { get; set; }

        /// <summary>
        /// Internal Id for the shipping profile for that order
        /// </summary>
        public string? ShippingProfileId { get; set; }

        /// <summary>
        /// Display Name of Shipping profile, if available
        /// </summary>
        public string? ShippingProfileName { get; set; }


        /// <summary>
        /// Internal Id for the used shipping provider
        /// </summary>
        public long? ShippingProviderId { get; set; }

        /// <summary>
        /// Internal Id for the used shipping product
        /// </summary>
        public long? ShippingProviderProductId { get; set; }

        /// <summary>
        /// The Name for of used shipping provider
        /// </summary>
        public string? ShippingProviderName { get; set; }

        /// <summary>
        /// The Name of the used shipping product
        /// </summary>
        public string? ShippingProviderProductName { get; set; }

        /// <summary>
        /// A textfield optionaly filled with a payment instruction text for printout on the invoice (z.B. Ebay Kauf auf Rechnung)
        /// </summary>
        public string? PaymentInstruction { get; set; }

        /// <summary>
        /// An optional Order Id (externalid) for an order if this is a cancel order (shopify only at the moment)
        /// </summary>
        public string? IsCancelationFor { get; set; }

        public string? PaymentTransactionId { get; set; }

        /// <summary>
        /// An optional Country ISO2 Code of the country where order is shipped from (FBA)
        /// </summary>
        public string? DeliverySourceCountryCode { get; set; }

        /// <summary>
        /// An optional multiline text which is printed on the invoice
        /// </summary>
        public string? CustomInvoiceNote { get; set; }

        /// <summary>
        /// The customer number (not to be confused with the id of the customer)
        /// </summary>
        public string? CustomerNumber { get; set; }
        
        /// <summary>
        /// The Customer object connected with the order
        /// </summary>
        public Customer? Customer { get; set; }
        
        /// <summary>
        /// List of payments, associated with this order
        /// </summary>
        public List<OrderPayment>? Payments { get; set; }
        
        public decimal AdjustmentCost { get; set; }
        public string? AdjustmentReason { get; set; }
        
        /// <summary>
        /// If set, the order was already archived at the given date. Further modification is disabled.
        /// </summary>
        public DateTime? ArchivedAt { get; set; }
        
        /// <summary>
        /// The vat-id, that was given by the customer to fulfill this order
        /// </summary>
        public string? CustomerVatId { get; set; }

        /// <summary>An optional code for the distribution center delivering this order</summary>
        public string? DistributionCenter { get; set; }
        
        /// <summary>
        /// Date of the last update, the order got
        /// </summary>
        public DateTime? LastModifiedAt { get; set; }
        
        /// <summary>
        /// The vat-id, that should be displayed on the invoice and other order documents
        /// </summary>
        public string? MerchantVatId { get; set; }
        
        /// <summary>
        /// List of history events of this order
        /// </summary>
        public List<HistoryEntry>? History { get; set; }
        
        public decimal RebateDifference { get; set; }
        
        /// <summary>
        /// If set, the order was restored from the archive at the given date.
        /// </summary>
        public DateTime? RestoredAt { get; set; }
    }
    
    public class HistoryEntry
    {
        public DateTime Created { get; set; }
        public string? EventTypeName { get; set; }
        public string? Text { get; set; }
        public string? EmployeeName { get; set; }
        public int? TypeId { get; set; }
    }
}
