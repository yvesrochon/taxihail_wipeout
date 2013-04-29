﻿using System.Text;
using System.Xml;
using ServiceStack.Service;
using ServiceStack.ServiceHost;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace MK.Booking.Api.Client
{

    public class CustomXmlServiceClient : IServiceClient, IRestClient
    {
        public CustomXmlServiceClient(string url, bool acceptAnyCert, IWebProxy proxy = null)
        {
            BaseUrl = url;
            if (acceptAnyCert)
            {
                //todo - Bug accept all certificates
                ServicePointManager.ServerCertificateValidationCallback = (p1, p2, p3, p4) => true;
            }
			if(proxy !=null)
			{
				Proxy = proxy;
			}
        }

        public string BaseUrl { get; set; }
		public IWebProxy Proxy { get; set; }

        static readonly Dictionary<Type, XmlSerializer> XmlSerializers = new Dictionary<Type, XmlSerializer>();
        public TimeSpan Timeout;
        public Action<WebRequest> LocalHttpWebRequestFilter;

        readonly XmlWriterSettings XmlWriterSettings = new XmlWriterSettings
        {
            Encoding = Encoding.ASCII,
            Indent = true,
            NewLineOnAttributes = true,
        };

        private static XmlSerializer GetOrCreate(Type t)
        {
            if (!XmlSerializers.ContainsKey(t))
            {
                XmlSerializers.Add(t, new XmlSerializer(t,""));
            }
            return XmlSerializers[t];
        }

        public string GetEndpoint(object obj)
        {
            var routeAttribute  = (RouteAttribute)Attribute.GetCustomAttributes(obj.GetType()).FirstOrDefault(att=>att is RouteAttribute);
            var path = "";
            if (routeAttribute != null)
            {
                path = routeAttribute.Path;
            }

            var toSwitch = path.Split('{').Skip(1).Select(item=>item.Split('}').First()).ToArray();
            
            foreach (var property in obj.GetType().GetProperties())
            {
                var match = toSwitch.FirstOrDefault(str=>str == property.Name);
                if(!string.IsNullOrEmpty(match))
                {
                    var value = property.GetValue(obj, null);
                    if (value == null)
                    {
                        value = "";
                    }
                    path= path.Replace("{" + match + "}", value.ToString());
                }
            }

            return path;
        }

		private TResponse DoWebRequest<TResponse>(IReturn<TResponse> request, string method="GET")
		{			
			var requestStream = new MemoryStream();
		    var xmlWriter = XmlWriter.Create(requestStream, XmlWriterSettings);
			var serializer = GetOrCreate(request.GetType());

            serializer.Serialize(xmlWriter, request);

			requestStream.Position = 0;
			
			var webRequest = WebRequest.Create(BaseUrl + GetEndpoint(request));
			webRequest.Method  = method;
			webRequest.ContentType = "application/xml";
			webRequest.ContentLength = requestStream.Length;
			if(Proxy!=null)
			{
				webRequest.Proxy=Proxy;
			}

			LocalHttpWebRequestFilter(webRequest);
			
			var os = webRequest.GetRequestStream();
			requestStream.WriteTo(os);
			
			var webResponse = webRequest.GetResponse();
#if DEBUG
            
		    var stream = new MemoryStream();
            webResponse.GetResponseStream().CopyTo(stream);
            stream.Position = 0;
		    var data = new StreamReader(stream).ReadToEnd();
		    stream.Position = 0;

            var responseObject = (TResponse)GetOrCreate(typeof(TResponse)).Deserialize(stream);
#else
            var responseObject = (TResponse)GetOrCreate(typeof(TResponse)).Deserialize(webResponse.GetResponseStream());

#endif

			
			return responseObject;        
		}
        
        public TResponse Post<TResponse>(IReturn<TResponse> request)
        {
			return DoWebRequest(request,"POST");
        }

        public TResponse Delete<TResponse>(IReturn<TResponse> request)
		{
			return DoWebRequest(request,"DELETE");
        }



        public void SendAsync<TResponse>(object request, Action<TResponse> onSuccess, Action<TResponse, Exception> onError)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync<TResponse>(string relativeOrAbsoluteUrl, Action<TResponse> onSuccess, Action<TResponse, Exception> onError)
        {
            throw new NotImplementedException();
        }

        public void GetAsync<TResponse>(string relativeOrAbsoluteUrl, Action<TResponse> onSuccess, Action<TResponse, Exception> onError)
        {
            throw new NotImplementedException();
        }

        public void PostAsync<TResponse>(string relativeOrAbsoluteUrl, object request, Action<TResponse> onSuccess, Action<TResponse, Exception> onError)
        {
            throw new NotImplementedException();
        }

        public void PutAsync<TResponse>(string relativeOrAbsoluteUrl, object request, Action<TResponse> onSuccess, Action<TResponse, Exception> onError)
        {
            throw new NotImplementedException();
        }

        public void SetCredentials(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void SendOneWay(string relativeOrAbsoluteUrl, object request)
        {
            throw new NotImplementedException();
        }

        public void SendOneWay(object request)
        {
            throw new NotImplementedException();
        }

        public TResponse PostFile<TResponse>(string relativeOrAbsoluteUrl, Stream fileToUpload, string fileName, string mimeType)
        {
            throw new NotImplementedException();
        }

        public TResponse PostFile<TResponse>(string relativeOrAbsoluteUrl, FileInfo fileToUpload, string mimeType)
        {
            throw new NotImplementedException();
        }

        public TResponse PostFileWithRequest<TResponse>(string relativeOrAbsoluteUrl, Stream fileToUpload, string fileName, object request)
        {
            throw new NotImplementedException();
        }

        public TResponse PostFileWithRequest<TResponse>(string relativeOrAbsoluteUrl, FileInfo fileToUpload, object request)
        {
            throw new NotImplementedException();
        }

        public void Send(IReturnVoid request)
        {
            throw new NotImplementedException();
        }

        public TResponse Send<TResponse>(IReturn<TResponse> request)
        {
            throw new NotImplementedException();
        }

        public TResponse Send<TResponse>(object request)
        {
            throw new NotImplementedException();
        }

        public TResponse CustomMethod<TResponse>(string httpVerb, IReturn<TResponse> request)
        {
            throw new NotImplementedException();
        }

        public void CustomMethod(string httpVerb, IReturnVoid request)
        {
            throw new NotImplementedException();
        }

        public TResponse Delete<TResponse>(string relativeOrAbsoluteUrl)
        {
            throw new NotImplementedException();
        }

        public void Delete(IReturnVoid request)
        {
            throw new NotImplementedException();
        }


        public TResponse Get<TResponse>(string relativeOrAbsoluteUrl)
        {
            throw new NotImplementedException();
        }

        public void Get(IReturnVoid request)
        {
            throw new NotImplementedException();
        }

        public TResponse Get<TResponse>(IReturn<TResponse> request)
        {
            throw new NotImplementedException();
        }

        public TResponse Patch<TResponse>(string relativeOrAbsoluteUrl, object request)
        {
            throw new NotImplementedException();
        }

        public void Patch(IReturnVoid request)
        {
            throw new NotImplementedException();
        }

        public TResponse Patch<TResponse>(IReturn<TResponse> request)
        {
            throw new NotImplementedException();
        }

        public TResponse Post<TResponse>(string relativeOrAbsoluteUrl, object request)
        {
            throw new NotImplementedException();
        }

        public void Post(IReturnVoid request)
        {
            throw new NotImplementedException();
        }

        public TResponse Put<TResponse>(string relativeOrAbsoluteUrl, object request)
        {
            throw new NotImplementedException();
        }

        public void Put(IReturnVoid request)
        {
            throw new NotImplementedException();
        }

        public TResponse Put<TResponse>(IReturn<TResponse> request)
        {
            throw new NotImplementedException();
        }


   
            

    }
}