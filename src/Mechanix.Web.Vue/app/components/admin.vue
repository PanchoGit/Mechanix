<template>
	<h2>Admin View</h2>
	<div class="app-center" style="width: 800px; height: 330px">One</div>
	<button class="button" style="position: absolute; margin: auto; bottom: 50px; left: 0px; right: 0px;" v-on:click="goHomeView">Home</button>
</template>

<style>
</style>

<script>
import config from '../configuration/config'

module.exports = {
	data: function(){
		return {
			users: []
		}
	},
	ready: function(){
	},
	methods: {
		goHomeView: function () {
			this.$dispatch(config.event.menu, config.view.home)
		}
	}
}
</script>