
<template>
    <v-card class="mx-auto" max-width="auto">
        <v-card-item class="bg-brown-lighten-4">
            <v-card-title>
                <span class="text-h5"></span>
            </v-card-title>

            <template v-slot:append>
                <v-defaults-provider :defaults="{
                    VBtn: {
                        variant: 'text',
                        density: 'comfortable',
                    }
                }">
                    <v-btn icon="mdi-chevron-left"></v-btn>

                    <v-btn icon="mdi-pencil"></v-btn>

                    <v-btn icon="mdi-dots-vertical"></v-btn>
                </v-defaults-provider>
            </template>
        </v-card-item>

        <v-list>
            <v-list-item append-icon="mdi-message-text" prepend-icon="mdi-phone" title="訂單編號"></v-list-item>
            <v-divider inset></v-divider>
            <v-list-item append-icon="mdi-message-text" prepend-icon="mdi-phone" title="成立日期"></v-list-item>
            <v-divider inset></v-divider>
            <v-list-item append-icon="mdi-message-text" prepend-icon="mdi-phone" title="完成日期"></v-list-item>
            <v-divider inset></v-divider>
            <v-list-item append-icon="mdi-message-text" prepend-icon="mdi-phone" title="寄送方式"></v-list-item>
            <v-divider inset></v-divider>
            <v-list-item append-icon="mdi-message-text" prepend-icon="mdi-phone" title="收件人"></v-list-item>
            <v-divider inset></v-divider>
            <v-list-item prepend-icon="mdi-email" title="mcbeal@example.com"></v-list-item>

            <v-divider inset></v-divider>

            <v-list-item prepend-icon="mdi-map-marker" title="收件地址"></v-list-item>
        </v-list>
    </v-card>
</template>

<script>
export default {
    props: {
        orderId: {
            required: true
        }
    }
}
</script>

<style></style>