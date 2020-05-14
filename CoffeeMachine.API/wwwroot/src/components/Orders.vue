<template>
    <div id="app">
        <Header></Header>
        <SubHeader title="Drink selection" />
            <v-app>
                <v-layout row>
                    <v-flex class="justify-center" style="margin : 1rem" >
                        <v-layout  class="justify-center">
                           
                            <v-form ref="form"
                                    v-model="valid"
                                    :lazy-validation="lazy">
                                <v-select 

                                          :items="drinks"
                                          v-model='drink'
                                          :rules="[v => !!v || 'Item is required']"
                                          label="Drink"
                                          item-text="name"
                                          item-value="id"
                                          required></v-select>

                                <v-subheader>Sugar amount</v-subheader>
                                <v-card-text>
                                    <v-slider v-model="sugarAmount"
                                              thumb-label="always" min="0" max="4"></v-slider>
                                </v-card-text>




                                <v-checkbox v-model="withMug"
                                            
                                            label="Do you have your own mug ?"
                                            required></v-checkbox>



                                <v-btn color="success"
                                       class="mr-4"
                                       @click="orderAgain">
                                    Order
                                </v-btn>


                            </v-form>
                        </v-layout>
                    </v-flex>
                    <v-flex class="justify-center" style="margin : 1rem">
                        <v-layout class="justify-center" >
                            
                                <h2 style="font-family:Avenir-Black" >Previous orders</h2>
                          
                        </v-layout>
                       
                        <v-layout md4 v-for="(item, i) in orders" :key="i" justify-center>
                            <v-card class="mx-auto"
                                    max-width="400" style="margin : 1rem">
                                <v-img class="white--text align-end"
                                       height="200px"
                                       src="../assets/img/cup.png">
                                    <v-card-title style="color:white;font-family:Avenir-Black;margin-left:3rem">Order number {{item.id}}</v-card-title>
                                </v-img>



                                <v-card-text class="text--primary">
                                 
                                    <div>Ordered on {{ item.orderTime | moment("MMMM Do YYYY, h:mm:ss a") }}</div>
                                  
                                    <div>Drink :  <b> {{ getDrinkName(item.drinkId) }}</b> </div>
                                    <div>Sugar amount : <b> {{item.sugarAmount}}</b> </div>
                                   
                                    <div v-if="item.withMug">With your own mug</div>
                                    <div v-else>Without your own mug</div>

                                </v-card-text>

                                <v-card-actions>
                                    
                                    <v-btn v-if="i==0" color="green" @click="orderAgain"
                                           text>
                                        Order again
                                    </v-btn>

                                </v-card-actions>
                            </v-card>

                        </v-layout>
                        
                    </v-flex>
                </v-layout>
                
            </v-app>

      
    </div>
</template>


<script>
    import Header from "./Header";
    import SubHeader from "./SubHeader";
    export default {
        name: "Orders.vue",
        components: { Header, SubHeader },
        data: () => {
            return {
                orders: [],
                drinks: [],
                badge : null,
                drink: '',
                withMug: false,
                sugarAmount : 0
            }
        },
        created() {
            
            this.$store
                .dispatch('getDrinks')
                .then(response => {
                    this.drinks = response.data;
                    
                }
                )
                .catch(err => this.displayError(err.response.status)
            );
            const id = this.$route.params.id;
           
            this.$store
                .dispatch('getOrdersByBadgeId', { id })
                .then(response => {
                    this.orders = response.data.reverse();
                   
                }
                )
                .catch(err => console.log(err)
            );
            
        },
        computed: {
            ordersExist() {
                if (this.orders.length > 0) return true
                return false;

            }
            
            
        },
        methods: {
            addOrder() {
                const badgeId = this.$route.params.id;
                const drinkId = this.drink;
                const withMug = this.withMug;
                const sugarAmount = this.sugarAmount;
               
                if (drinkId == '') {
                    alert('You have to select a drink !');
                    return;
                }
                const orderTime = new Date();


                this.$store
                    .dispatch('addOrder', { badgeId, drinkId, withMug, sugarAmount, orderTime })
                    .then(() => {
                        this.$router.push('/badges')
                       
                    })
                    
            },
            orderAgain() {
                
                var badgeId = this.orders[0]["badgeId"];
                var drinkId = this.orders[0]["drinkId"];
                var withMug = this.orders[0]["withMug"];
                var sugarAmount = this.orders[0]["sugarAmount"];
                console.log('id' + badgeId);
                console.log(drinkId);
                console.log(withMug);
                console.log(sugarAmount);
                var orderTime = new Date();
                this.$store
                    .dispatch('addOrder', {badgeId, drinkId, withMug, sugarAmount, orderTime })
                    .then(() => {

                        this.$router.push("/badges/" + badgeId + "/orders");

                    })
                    .catch(err => {
                        console.log(err);
                        this.$router.push("/badges/" + badgeId + "/orders");
                    });
            },
            getDrinkName(id) {
                return this.drinks[id-1]["name"];
                
            }
        },
       
        
    }
</script>


<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>

    h1, h2 {
        font-weight: normal;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

    li {
        display: inline-block;
        margin: 0 10px;
    }

    a {
        color: #35495E;
    }
</style>

