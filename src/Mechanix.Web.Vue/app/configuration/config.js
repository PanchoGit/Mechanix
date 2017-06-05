var Vue = require('vue');
var VueResource = require('vue-resource');
Vue.use(VueResource);
import authService from '../services/authService'

export default {
	register: function(root){
		if(this.initiated) return;
		this.initiated = true;
		this.root = root;
		Vue.config.debug = true
		Vue.config.devtools = true
		Vue.http.headers.common['Authorization'] = authService.getAuthHeader();
		this.configPages();
	},
	initiated:false,
	root:null,
	view: {
		home: 'homeView',
		form: 'formView'
	},
	event: {
		menu: 'menu'
	},
	endpoints: {
		services: '/api/services',
		owners: '/api/owners',
		cars: '/api/cars'
	},
    configPages: function(){
      var self = this;
      var bus = this.root;
      page('/home', function(){ bus.$dispatch(self.event.menu, self.view.home) })
      page('/form', function(){ bus.$dispatch(self.event.menu, self.view.form) })
      page('/', function(){ bus.$dispatch(self.event.menu, self.view.form) })
      page()
    }
}