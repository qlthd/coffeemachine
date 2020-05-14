<template>
    <div id="app">
        <Header></Header>
        <v-app>
            <v-content>
                <SubHeader title="Coffee machine "></SubHeader>
                <div>
                    <v-row style="width:100%">
                        <v-col>
                            <v-container>
                              
                                       
                                      
                                        <v-card-actions class="justify-center">
                                            <router-link to="/badges">
                                                <v-btn >
                                                    Start                                                
                                                </v-btn>
                                            </router-link>
                                        </v-card-actions>
                            </v-container>

                        </v-col>

                    </v-row>

                    
                </div>
            </v-content>
        </v-app>
        
    </div>
</template>

<script>
    import Header from "./Header";
    import SubHeader from "./SubHeader";
   

    export default {
        name: "Home.vue",
        components: {Header,SubHeader}
    }
</script>

<style scoped>



  
    .start-btn{
        text-align: center;
        color : #349868;
        margin : 2%;
        font-size: 30px;
        font-family: "Avenir-Black";
    }

  

    

    h2{
        margin: auto;
        text-align: center;
        font-size : 35px;
        font-family: "Avenir-Light";
    }
</style>