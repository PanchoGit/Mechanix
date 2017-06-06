<template>
	<h2>Home</h2>
	<div class="app-center" style="width: 500px; height: 150px;" align="center">
	{{ message }}
	</div>
	<button class="button" style="position: absolute; margin: auto; bottom: 50px; left: 0px; right: 0px;" v-on:click="goFormView">Form</button>
</template>

<style>
</style>

<script>
import config from '../configuration/config'

module.exports = {
	data: function(){
		return {
			message: ''
		}
	},
	ready: function(){
		console.log("home.view.1");
		this.init();
	},
	methods: {
		init: function(){
		},
		goFormView: function () {
			this.$dispatch(config.event.menu, config.view.form)
		}
	}
}
</script>