// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/product.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace PhoneStore.Application.Protos {
  public static partial class ProductsBuf
  {
    static readonly string __ServiceName = "productsbuf.ProductsBuf";

    static readonly grpc::Marshaller<global::PhoneStore.Application.Protos.ProductBuf> __Marshaller_productsbuf_ProductBuf = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PhoneStore.Application.Protos.ProductBuf.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Empty.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PhoneStore.Application.Protos.ProductsReply> __Marshaller_productsbuf_ProductsReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PhoneStore.Application.Protos.ProductsReply.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PhoneStore.Application.Protos.DeleteProductBuf> __Marshaller_productsbuf_DeleteProductBuf = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PhoneStore.Application.Protos.DeleteProductBuf.Parser.ParseFrom);

    static readonly grpc::Method<global::PhoneStore.Application.Protos.ProductBuf, global::Google.Protobuf.WellKnownTypes.Empty> __Method_AddProduct = new grpc::Method<global::PhoneStore.Application.Protos.ProductBuf, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddProduct",
        __Marshaller_productsbuf_ProductBuf,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::PhoneStore.Application.Protos.ProductBuf, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UpdateProduct = new grpc::Method<global::PhoneStore.Application.Protos.ProductBuf, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateProduct",
        __Marshaller_productsbuf_ProductBuf,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::PhoneStore.Application.Protos.ProductsReply> __Method_GetAllProducts = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::PhoneStore.Application.Protos.ProductsReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllProducts",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_productsbuf_ProductsReply);

    static readonly grpc::Method<global::PhoneStore.Application.Protos.DeleteProductBuf, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeleteProduct = new grpc::Method<global::PhoneStore.Application.Protos.DeleteProductBuf, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteProduct",
        __Marshaller_productsbuf_DeleteProductBuf,
        __Marshaller_google_protobuf_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::PhoneStore.Application.Protos.ProductReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ProductsBuf</summary>
    [grpc::BindServiceMethod(typeof(ProductsBuf), "BindService")]
    public abstract partial class ProductsBufBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> AddProduct(global::PhoneStore.Application.Protos.ProductBuf request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> UpdateProduct(global::PhoneStore.Application.Protos.ProductBuf request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::PhoneStore.Application.Protos.ProductsReply> GetAllProducts(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> DeleteProduct(global::PhoneStore.Application.Protos.DeleteProductBuf request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(ProductsBufBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_AddProduct, serviceImpl.AddProduct)
          .AddMethod(__Method_UpdateProduct, serviceImpl.UpdateProduct)
          .AddMethod(__Method_GetAllProducts, serviceImpl.GetAllProducts)
          .AddMethod(__Method_DeleteProduct, serviceImpl.DeleteProduct).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ProductsBufBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_AddProduct, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PhoneStore.Application.Protos.ProductBuf, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.AddProduct));
      serviceBinder.AddMethod(__Method_UpdateProduct, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PhoneStore.Application.Protos.ProductBuf, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.UpdateProduct));
      serviceBinder.AddMethod(__Method_GetAllProducts, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Google.Protobuf.WellKnownTypes.Empty, global::PhoneStore.Application.Protos.ProductsReply>(serviceImpl.GetAllProducts));
      serviceBinder.AddMethod(__Method_DeleteProduct, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PhoneStore.Application.Protos.DeleteProductBuf, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.DeleteProduct));
    }

  }
}
#endregion
