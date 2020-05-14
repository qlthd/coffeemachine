<template>
    <div id="app">
        <Header></Header>
        <SubHeader title="Choose a badge" />
        <v-app>
            <v-layout md4  v-for="(item, i) in badges" :key="i" justify-center>
                <v-card class="mx-auto"
                        max-width="400" style="margin : 1rem">
                    <v-img class="white--text align-end"
                           height="200px"
                           src="../assets/img/business.png">
                        <v-card-title style="color:black;font-family:Avenir-Black" >Badge number {{item.id}}</v-card-title>
                    </v-img>



                    <v-card-text class="text--primary">
                        <div>Owner :  {{item.ownerFirstName}} {{item.ownerLastName}}</div>

                        
                    </v-card-text>

                    <v-card-actions>
                        <router-link :to="'/badges/' + item.id + '/orders'">
                            <v-btn color="green"
                                   text>
                                Use
                            </v-btn>
                        </router-link>

                    </v-card-actions>
                </v-card>
                
                </v-layout>

        </v-app>
        
    </div>
</template>


<script>
    import Header from "./Header";
    import SubHeader from "./SubHeader";
    export default {
        name: "Badges.vue",
        components: { Header, SubHeader },

        data: () => {
            return {
                item : null,
                badges: []
            }
        },
        created() {
            this.$store.dispatch('getBadges')
                .then(response => {
                    this.badges = response.data;
                   



                })
                .catch(err =>
                    console.log(err)
                );
        },
        computed: {
            badgesExist() {
                if (this.badges.length > 0) return true
                return false

            }

        }
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

