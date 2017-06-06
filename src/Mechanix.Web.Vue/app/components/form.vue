<template>

<h2>Auto</h2>
<div class="app-center" style="width: 500px;" align="center">
  <form v-on:submit.prevent="save" class="form-horizontal">
    <div class="form-group">
      <label class="col-sm-2 control-label" for="brand">Marca</label>
      <div class="col-sm-10 input-group">
        <span class="input-addon"><span class="glyphicon glyphicon-tag" aria-hidden="true"></span></span>
        <input class="input-with-addon" id="brand" name="brand" style="width: 300px" v-model="car.brand" />
      </div>
    </div>
    <div class="form-group">
      <label class="col-sm-2 control-label" for="year">Año</label>
      <div class="col-sm-10 input-group">
        <span class="input-addon"><span class="glyphicon glyphicon-tag" aria-hidden="true"></span></span>
        <input class="input-with-addon" id="year" name="year" style="width: 300px" v-model="car.year" />
      </div>
    </div>
    <div class="form-group">
      <label class="col-sm-2 control-label" for="patent">Patente</label>
      <div class="col-sm-10 input-group">
        <span class="input-addon"><span class="glyphicon glyphicon-tag" aria-hidden="true"></span></span>
        <input class="input-with-addon" id="patent" name="patent" style="width: 300px" v-model="car.patent" />
      </div>
    </div>
    <div class="form-group">
      <label class="col-sm-2 control-label" for="owner">Propietario</label>
      <div class="col-sm-10 input-group">
        <span class="input-addon"><span class="glyphicon glyphicon-user" aria-hidden="true"></span></span>
        <select v-model="car.owner" class="input-with-addon" id="owner" name="owner" style="width: 275px">
          <option disabled value=""></option>
          <option v-for="option in owners" v-bind:value="option">
            {{ option.firstName +' '+ option.lastName }}
          </option>
        </select>
        <button type="button" class="input-with-addon" v-on:click="newOwnerClickHandler"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></button>
      </div>
    </div>
    <div class="form-group">
      <label class="col-sm-2 control-label" for="service">Servicios</label>
        <div class="col-sm-10 input-group">
          <v-select class="inputVSelect" style="width:355px" :value.sync="selectedServices" :options="services" options-value="id" options-label="name" multiple name="service" search justified clear-button close-on-select placeholder=" &nbsp; "></v-select>
        </div>
    </div>
    <div class="form-group">
      <button type="submit" name="" class="button" :disabled="submited">Guardar</button>
    </div>
  </form>

<alert
  :show.sync="showValidateAlert"
  :duration="3000"
  type="danger"
  width="400px"
  placement="top"
  dismissable>
  <span class="icon-info-circled alert-icon-float-left"></span>
  <div style="text-align:left">
    <div v-show="!validation.brand">
      <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
      Brand cannot be empty.
    </div>
    <div v-show="!validation.year">
      <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
      Year cannot be empty.
    </div>
    <div v-show="!validation.patent">
      <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
      Patent cannot be empty.
    </div>
    <div v-show="!validation.service">
      <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
      Service cannot be empty.
    </div>
    <div v-show="!validation.ownerFirstName">
      <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
      Owner first name cannot be empty.
    </div>
    <div v-show="!validation.ownerLastName">
      <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
      Owner last name cannot be empty.
    </div>
  </div>
</alert>

<alert
  :show.sync="showErrorAlert"
  :duration="12000"
  type="danger"
  width="400px"
  placement="top"
  dismissable>
  <span class="icon-info-circled alert-icon-float-left"></span>
  <div style="text-align:left">
    <div>
      <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
      <strong>{{ errorMessage.error }}</strong>
      <div v-html="errorMessage.description"></p>
    </div>
  </div>
</alert>


<alert :show.sync="submited" placement="top-right" duration="3000" type="success" width="400px" dismissable>
  <span class="icon-ok-circled alert-icon-float-left"></span>
  <strong>Well Done!</strong>
  <p>You successfully read this important alert message.</p>
</alert>

<modal title="Propietario" :show.sync="showOwnerModal" effect="zoom" width="400" ok-text="Guardar" cancel-text="Cancelar" :backdrop='false' :callback="newOwnerModalHandler">
  <div slot="modal-header" class="modal-header">
    <b>Propietario</b>
  </div>

  <div slot="modal-body" class="modal-body">
    <div class="form-group">
      <label class="col-sm-2 control-label" for="ownerFirstName">Nombre</label>
      <div class="col-sm-10 input-group">
        <span class="input-addon"><span class="glyphicon glyphicon-tag" aria-hidden="true"></span></span>
        <input class="input-with-addon" id="ownerFirstName" name="ownerFirstName" style="width: 300px" v-model="newOwner.firstName" />
      </div>
    </div>
    <div class="form-group">
      <label class="col-sm-2 control-label" for="ownerLastName">Apellido</label>
      <div class="col-sm-10 input-group">
        <span class="input-addon"><span class="glyphicon glyphicon-tag" aria-hidden="true"></span></span>
        <input class="input-with-addon" id="ownerLastName" name="ownerLastName" style="width: 300px" v-model="newOwner.lastName" />
      </div>
    </div>
  </div>
</modal>

</div>

</template>

<script>

import {alert as Alert} from 'vue-strap'
import validators from '../helpers/validators'
import config from '../configuration/config'
import serviceService from '../services/serviceService'
import ownerService from '../services/ownerService'
import carService from '../services/carService'
import {modal as Modal} from 'vue-strap'
import {select as vSelect} from 'vue-strap'

export default {
  data () {
    return {
      services:[],
      owners:[],
      car: {
        brand: '',
        year: '',
        patent: '',
        owner: {
          firstName: '',
          lastName: ''
        },
        services: []
      },
      newOwner: {
        id: 0,
        firstName: '',
        lastName: ''
      },
      selectedServices: [],
      showValidateAlert: false,
      showErrorAlert: false,
      showOwnerModal: false,
      currentViewName: 'form',
      errorMessage: { error:'', description:''},
      submited: false
    }
  },
  components: {
    Alert,
    Modal,
    vSelect
  },
  ready: function () {
    this.init();
  },
  computed: {
    validation: function () {
      return {
        brand: !!this.car.brand.trim(),
        year: !!this.car.year.trim(),
        patent: !!this.car.patent.trim(),
        service: !!this.car.services.length > 0,
        ownerFirstName: !!this.car.owner.firstName.trim(),
        ownerLastName: !!this.car.owner.lastName.trim()
      }
    },
    isValid: function () {
      var validation = this.validation;
      return Object.keys(validation).every(function (key) { return validation[key] });
    }
  },
  methods: {
    init: function(){
      this.getOwners();
      this.getServices();
    },
    validate: function(){
      return true;
    },
    goHomeView: function () {
      this.$dispatch(config.event.menu, config.view.home)
    },
    getOwners: function(){
      ownerService.get(this, this.ownerResponseHandler)
    },
    getServices: function(){
      serviceService.get(this, this.serviceResponseHandler)
    },
    ownerResponseHandler: function(result){
      if(this.errorHandler(result)) return;
      this.owners = result.data;
    },
    serviceResponseHandler: function(result){
      if(this.errorHandler(result)) return;
      this.services = result.data;
    },
    saveResponseHandler: function(result){
      console.log(result);
      if(this.errorHandler(result)) return;
      alert("ok");
    },
    errorHandler: function(result){
      if(result.data.status == undefined && result.ok) return false;
      if(result.data.status == "OK") return false;
      this.errorMessage = this.translateError(result.data);
      this.showErrorAlert = true;
      return true;
    },
    translateError: function(data){
      var message = "Error";
      var description = "";

      if(data.status == undefined)
      {
        message = data.message ? data.message : message;
        description = data.exceptionMessage ? data.exceptionMessage : data;
      } 

      if(data.status != undefined && data.status == "ERROR")
      {
        message = "Error";
        for(var item in data.errors){
          var errorItem = data.errors[item];
          description += "<li>"+ errorItem.errorMessage + "</li>";
        }
      }

      return {error:message, description:description};
    },
    save: function(){
      this.setSelectedServices();
      //if(!this.isValid) {
        //this.showValidateAlert = true;
        //return;
      //}
      //this.submited = true;
      carService.post(this, this.car, this.saveResponseHandler);
    },
    setSelectedServices: function(){
      var list = [];
      for(var index in this.selectedServices){
        list.push({id:this.selectedServices[index]});
      }
      this.car.services = list;
    },
    newOwnerClickHandler: function(){
      this.car.owner = null;
      this.showOwnerModal = true;
    },
    newOwnerModalHandler: function(){
      this.owners.push(this.newOwner);
      this.showOwnerModal = false;
      this.car.owner = this.newOwner;
    }
  }
}
</script>

<style>

</style>
