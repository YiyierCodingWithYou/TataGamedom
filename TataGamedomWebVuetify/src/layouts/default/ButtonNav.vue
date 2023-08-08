<template>
    <header>
        <v-bottom-navigation :elevation="7" grow>
            <v-btn RouterLink to="/Orders" value="Order">
                <v-icon>mdi-history</v-icon>

                Order
            </v-btn>

            <v-btn RouterLink to="/SupportHub" value="SupportHub">
                <v-icon color="warning" icon="mdi-information" size="large"></v-icon>

                SupportHub
            </v-btn>
        </v-bottom-navigation>
    </header>
</template>

<script setup>

</script>