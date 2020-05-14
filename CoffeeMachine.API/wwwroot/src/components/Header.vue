<template>
    <div class="header-body">
        <div class="left-menu">
            <div class="item-menu">
                <router-link to="/" >
                    <img :src="require('@/assets/img/coffee.png')"  class="coffeemachine-logo"/>
                    
                </router-link>
            </div>
            <div class="line"></div>
            <div class="item-menu">
                <router-link to="/badges"> Access to Badges</router-link>
            </div>
            
        </div>
        
    </div>
</template>

<script>
    export default {
        
        data: () => ({
           
        })
    }
</script>

<style scoped>
    .header-body{
        width: 100%;
        display: block;
    }



    .item-menu {
        margin: 1rem .5rem;
        cursor: pointer;
        display: inline-block;
        vertical-align: middle;
    }




    .item-menu a{
        text-decoration: none;
        color:black;
    }

    .item-menu a:hover{
        font-weight: bold;
    }

    a:visited{
        color : black;
    }

    .coffeemachine-logo{
        max-width: 2rem;
    }

    .line{
        width: 1px;
        height: .75rem;
        background: #999;
        margin: 0 1rem;
        display: inline-block;
    }

    .left-menu{
        margin-left: .5rem;
        display: inline-block;
    }

    .right-menu{
        float: right;
        margin-right: .5rem;
        display: inline-block;
    }

    .right-menu-content{
        height: 100%;
        line-height: 2rem;
        vertical-align: middle;
    }
</style>