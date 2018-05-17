import Vue from 'vue';
import Vuex from 'vuex';

import app from './modules/app';
import user from './modules/user';
import session from './modules/session'
import account from './modules/account'
import role from './modules/role'
import customer from './modules/customer'
import job from './modules/job'
import product from './modules/product'

Vue.use(Vuex);

const store = new Vuex.Store({
    state: {
        //
    },
    mutations: {
        //
    },
    actions: {

    },
    modules: {
        app,
        user,
        session,
        account,
        role,
        job,
        product,
        customer
    }
});

export default store;