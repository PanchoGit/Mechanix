var Vue = require('vue');
var VueResource = require('vue-resource');
import config from '../configuration/config'
Vue.use(VueResource);

export default {
	login : function(context, data, callback)
	{
		var credential = {
			grant_type: 'password',
			client_id: 'TWFsZWJvZ2asfAFAADYUNvdWxldXI=',
			username: data.username,
			password: btoa(data.password)
		}

		context.$http.post(config.endpoints.oauth, credential, {
			emulateJSON: true
		}).then((response) => { 
			this.loginSuccess(response, callback) 
		}, callback);
	},
	getAuthHeader : function() {
    	return 'Bearer ' + localStorage.getItem('token');
	},
	loginSuccess : function(response, callback){
		localStorage.setItem('token', response.data.access_token);
		Vue.http.headers.common['Authorization'] = this.getAuthHeader();
		callback(response);
	}
}