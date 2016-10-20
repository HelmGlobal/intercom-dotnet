using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Intercom.Data;
using Intercom.Exceptions;
using Newtonsoft.Json;

namespace Intercom.Core
{
	public class Client
	{
		protected const String INTERCOM_API_BASE_URL = "https://api.intercom.io/";
		protected const String CONTENT_TYPE_VALUE = "application/json";
		protected const String ACCEPT_VALUE = "application/json";
		protected const String ACCEPT_CHARSET_VALUE = "UTF-8";
		protected const String USER_AGENT_VALUE = "intercom-dotnet/2.1-preview1";

		protected readonly String URL;
		protected readonly String RESRC;
		protected readonly Authentication AUTH;

		public Client(String url, String resource, Authentication authentication)
		{
			if (authentication == null)
				throw new ArgumentNullException(nameof(authentication));
				
			if (String.IsNullOrEmpty(url))
				throw new ArgumentNullException(nameof(url));

			if (String.IsNullOrEmpty(resource))
				throw new ArgumentNullException(nameof(resource));

			this.URL = url;
			this.RESRC = resource;
			this.AUTH = authentication;
		}

		protected virtual ClientResponse<T> Get<T>(
			Dictionary<String, String> headers = null,
			Dictionary<String, String> parameters = null,
			String resource = null)
			where T : class
		{
			ClientResponse<T> clientResponse = null;

			try
			{
				var client = BuildClient();
				var request = BuildRequest(httpMethod: "GET", headers: headers, parameters: parameters, resource: resource);
				var response = client.SendAsync(request).Result;
				clientResponse = HandleResponse<T>(response);
			}
			catch(ApiException ex)
			{
				throw ex;
			}
			catch (JsonConverterException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw new IntercomException(String.Format("An exception occurred " +
						"while calling the endpoint. Method: {0}, Url: {1}, Resource: {2}, Sub-Resource: {3}",
						"GET", URL, RESRC, resource), ex); 
			}

			return clientResponse;
		}

		protected virtual ClientResponse<T> Post<T>(String body, 
													Dictionary<String, String> headers = null, 
													Dictionary<String, String> parameters = null,
													String resource = null)
			where T : class
		{
			if (String.IsNullOrEmpty(body))
			{
				throw new ArgumentNullException(nameof(body));
			}

			ClientResponse<T> clientResponse = null;

			try
			{
				var client = BuildClient();
				var request = BuildRequest(httpMethod: "POST", headers: headers, parameters: parameters, body: body, resource: resource);
				var response = client.SendAsync(request).Result;
				clientResponse = HandleResponse <T>(response);
			}
			catch(ApiException ex)
			{
				throw ex;
			}
			catch (JsonConverterException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw new IntercomException(String.Format("An exception occurred " +
						"while calling the endpoint. Method: {0}, Url: {1}, Resource: {2}, Sub-Resource: {3}, Body: {4}",
						"POST", URL, RESRC, resource, body), ex); 
			}

			return clientResponse;
		}

		protected virtual ClientResponse<T> Post<T>(T body, 
													Dictionary<String, String> headers = null, 
													Dictionary<String, String> parameters = null,
													String resource = null)
			where T : class
		{
			if (body == null)
			{
				throw new ArgumentNullException(nameof(body));
			}

			ClientResponse<T> clientResponse = null;

			try
			{
				String requestBody = Serialize<T>(body);
				var client = BuildClient();
				var request = BuildRequest(httpMethod: "POST", headers: headers, parameters: parameters, body: requestBody, resource: resource);
				var response = client.SendAsync(request).Result;
				clientResponse = HandleResponse <T>(response);
			}
			catch(ApiException ex)
			{
				throw ex;
			}
			catch (JsonConverterException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw new IntercomException(String.Format("An exception occurred " +
						"while calling the endpoint. Method: {0}, Url: {1}, Resource: {2}, Sub-Resource: {3}, Body-Type: {4}",
						"POST", URL, RESRC, resource, typeof(T)), ex); 
			}

			return clientResponse;
		}

		protected virtual ClientResponse<T> Put<T>(String body, 
												   Dictionary<String, String> headers = null, 
												   Dictionary<String, String> parameters = null,
												   String resource = null)
			where T : class
		{
			if (String.IsNullOrEmpty(body))
			{
				throw new ArgumentNullException(nameof(body));
			}

			ClientResponse<T> clientResponse = null;

			try
			{
				var client = BuildClient();
				var request = BuildRequest(httpMethod: "PUT", headers: headers, parameters: parameters, body: body, resource: resource);
				var response = client.SendAsync(request).Result;
				clientResponse = HandleResponse <T>(response);
			}
			catch(ApiException ex)
			{
				throw ex;
			}
			catch (JsonConverterException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw new IntercomException(String.Format("An exception occurred " +
						"while calling the endpoint. Method: {0}, Url: {1}, Resource: {2}, Sub-Resource: {3}, Body: {4}",
						"POST", URL, RESRC, resource, body), ex); 
			}

			return clientResponse;
		}

		protected virtual ClientResponse<T> Put<T>(T body, 
												   Dictionary<String, String> headers = null, 
												   Dictionary<String, String> parameters = null,
												   String resource = null)
			where T : class
		{
			if (body == null)
			{
				throw new ArgumentNullException(nameof(body));
			}

			ClientResponse<T> clientResponse = null;

			try
			{
				String requestBody = Serialize<T>(body);
				var client = BuildClient();
				var request = BuildRequest(httpMethod: "PUT", headers: headers, parameters: parameters, body: requestBody, resource: resource);
				var response = client.SendAsync(request).Result;
				clientResponse = HandleResponse <T>(response);
			}
			catch(ApiException ex)
			{
				throw ex;
			}
			catch (JsonConverterException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw new IntercomException(String.Format("An exception occurred " +
						"while calling the endpoint. Method: {0}, Url: {1}, Resource: {2}, Sub-Resource: {3}",
						"POST", URL, RESRC, resource), ex); 
			}

			return clientResponse;
		}

		protected virtual ClientResponse<T>  Delete<T>(
			Dictionary<String, String> headers = null, 
			Dictionary<String, String> parameters = null,
			String resource = null)
			where T : class
		{
			ClientResponse<T> clientResponse = null;

			try
			{
				var client = BuildClient();
				var request = BuildRequest(httpMethod: "DELETE", headers: headers, parameters: parameters, resource: resource);
				var response = client.SendAsync(request).Result;
				clientResponse = HandleResponse<T>(response);
			}
			catch(ApiException ex)
			{
				throw ex;
			}
			catch (JsonConverterException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw new IntercomException(String.Format("An exception occurred " +
						"while calling the endpoint. Method: {0}, Url: {1}, Resource: {2}, Sub-Resource: {3}",
						"POST", URL, RESRC, resource), ex); 
			}
		
			return clientResponse;
		}

		protected virtual HttpRequestMessage BuildRequest(string httpMethod = "GET",
													Dictionary<String, String> headers = null, 
													Dictionary<String, String> parameters = null, 
													String body = null,
													String resource = null)
		{
			var final = String.IsNullOrEmpty(resource) ? RESRC : resource;
			HttpRequestMessage request = new HttpRequestMessage();
			request.RequestUri = new Uri(URL + final);
			request.Headers.TryAddWithoutValidation("Content-Type", CONTENT_TYPE_VALUE);
			request.Headers.TryAddWithoutValidation("Accept-Charset", ACCEPT_CHARSET_VALUE);
			request.Headers.TryAddWithoutValidation("Accept", ACCEPT_VALUE);
			request.Headers.TryAddWithoutValidation("User-Agent", USER_AGENT_VALUE);

			if (headers != null && headers.Any())
				AddHeaders(request, headers);

			if (parameters != null && parameters.Any())
				AddParameters(request, parameters);

			if (!String.IsNullOrEmpty(body))
				AddBody(request, body);

			return request;
		}

		protected virtual HttpClient BuildClient()
		{
			var client = new HttpClient();

			byte[] authData = new byte[0];
			if (!String.IsNullOrEmpty(AUTH.AppId) && !String.IsNullOrEmpty(AUTH.AppKey))
				authData = Encoding.ASCII.GetBytes($"{AUTH.AppId}:{AUTH.AppKey}");
			else
				authData = Encoding.ASCII.GetBytes($"{AUTH.PersonalAccessToken}:{string.Empty}");
			
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authData));

			return client;
		}

		protected virtual void AddHeaders(HttpRequestMessage request, 
										  Dictionary<String, String> headers)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			if (headers == null)
				throw new ArgumentNullException(nameof(headers));

			foreach (var header in headers)
				request.Headers.TryAddWithoutValidation(header.Key, header.Value);
		}

		protected virtual void AddParameters(HttpRequestMessage request, 
											 Dictionary<String, String> parameters)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			var url = request.RequestUri.ToString();
			url += "?" + string.Join("&",
				parameters.Select(kvp =>
					string.Format("{0}={1}", kvp.Key, kvp.Value)));

			request.RequestUri = new Uri(url);
		}

		protected virtual void AddBody(HttpRequestMessage request, String body)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			if (!String.IsNullOrEmpty(body))
				request.Content = new StringContent(body, Encoding.UTF8, "application/json");
		}

		protected virtual ClientResponse<T> HandleResponse<T>(HttpResponseMessage response)
			where T: class
		{
			ClientResponse<T> clientResponse = null;
			int statusCode = (int)response.StatusCode;

			if (statusCode >= 200 && statusCode < 300)
				clientResponse = HandleNormalResponse <T>(response) as ClientResponse<T>;
			else
				clientResponse = HandleErrorResponse <T>(response) as ClientResponse<T>;

			AssertIfAnyErrors(clientResponse);

			return clientResponse;
		}

		protected T Deserialize<T>(String data)
			where T : class
		{
			return JsonConvert.DeserializeObject(data, typeof(T)) as T;
		}

		protected String Serialize<T>(T data)
			where T : class
		{
			return JsonConvert.SerializeObject(data,
				typeof(T),
				Formatting.None, 
				new JsonSerializerSettings
				{ 
					NullValueHandling = NullValueHandling.Ignore
				});
		}

		protected ClientResponse<T> HandleErrorResponse<T>(HttpResponseMessage response)
			where T : class
		{
			if (String.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result))
			{
				return new ClientResponse<T>(response: response);
			}
			else
			{
				Errors errors = Deserialize<Errors>(response.Content.ReadAsStringAsync().Result);
				return new ClientResponse<T>(response: response, errors: errors);
			}
		}

		protected ClientResponse<T> HandleNormalResponse<T>(HttpResponseMessage response)
			where T : class
		{
			return new ClientResponse<T>(response: response, result: Deserialize<T>(response.Content.ReadAsStringAsync().Result));
		}

		protected void AssertIfAnyErrors<T>(ClientResponse<T> response)
			where T : class
		{
			if (response.Errors != null && response.Errors.errors != null && response.Errors.errors.Any())
			{
				throw new ApiException((int)response.Response.StatusCode, 
					response.Response.StatusCode.ToString(),
					response.Errors,
					response.Response.Content.ReadAsStringAsync().Result);
			}
		}
	}
}
