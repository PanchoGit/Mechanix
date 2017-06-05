import config from '../configuration/config'

export default {
	post : function(context, data, callback)
	{
		context.$http.post(config.endpoints.cars, data).then(callback, callback);
	}
}