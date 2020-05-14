import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
const api = process.env.VUE_APP_API
import VuexPersist from 'vuex-persist'
const vuexPersist = new VuexPersist({
    key: 'coffeemachinewebapp',
    storage: window.localStorage
})

Vue.use(Vuex)

const state = {
    token : null
}

const actions = {
    getBadgeById({ commit }, { id }) {
        return new Promise((resolve, reject) => {
            console.log(commit)
            axios.get(api+'badges', {
                params: {
                    id: id
                }
            })
                .then(response => resolve(response))
                .catch(err => {
                    reject(err)
                });
        })
    },
    getBadges({ commit }) {
        return new Promise((resolve, reject) => {
            console.log(commit)
            axios.get(api + 'badges').then(resp => {
                resolve(resp)
            })
                .catch(err => {
                    reject(err)
                })
        })
    },
    getDrinks({ commit }) {
        return new Promise((resolve, reject) => {
            console.log(commit)
            axios.get(api + 'drinks').then(resp => {
                resolve(resp)
            })
                .catch(err => {
                    reject(err)
                })
        })
    },
    getOrdersByBadgeId({ commit }, {id}) {
        return new Promise((resolve, reject) => {
            console.log(commit)
            console.log(api + 'badges/' + id + '/orders');
            axios.get(api + 'badges/'+id+'/orders').then(resp => {
                resolve(resp)
            })
                .catch(err => {
                    reject(err)
                })
        })
    },
    addOrder({ commit }, { badgeId, drinkId, withMug, sugarAmount, orderTime }) {
        return new Promise((resolve, reject) => {
            console.log(commit)
            console.log('/orders' + badgeId + drinkId + withMug + sugarAmount + orderTime)
           

            axios.post(api + 'orders', {
                badgeId: parseInt(badgeId),
                drinkId: drinkId,
                withMug: withMug,
                sugarAmount: sugarAmount,
                orderTime : orderTime
            }).then(resp => {
                console.log(resp);
                resolve(resp)
            })
                .catch(err => {
                    console.log(err);
                    reject(err)
                })

        })
    }
   
}

const mutations = {
   

}

const getters = {

}

export default new Vuex.Store({
    state: state,
    getters: getters,
    mutations: mutations,
    actions: actions,
    plugins: [vuexPersist.plugin]
})
