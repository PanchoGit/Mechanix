import config from '../configuration/config'

export default {
	get : function(context, callback)
	{
		context.$http.get(config.endpoints.services).then(callback, callback);
	}
}