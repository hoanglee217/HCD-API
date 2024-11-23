# For more information on configuration, see:
#   * Official English Documentation: http://nginx.org/en/docs/
#   * Official Russian Documentation: http://nginx.org/ru/docs/

user nginx;
worker_processes auto;
error_log /var/log/nginx/error.log;
pid /run/nginx.pid;

# Load dynamic modules. See /usr/share/doc/nginx/README.dynamic.
include /usr/share/nginx/modules/*.conf;

events {
    worker_connections 1024;
}

http {
    log_format  main  '$remote_addr - $remote_user [$time_local] "$request" '
                      '$status $body_bytes_sent "$http_referer" '
                      '"$http_user_agent" "$http_x_forwarded_for"';

    access_log  /var/log/nginx/access.log  main;

    sendfile            on;
    tcp_nopush          on;
    tcp_nodelay         on;
    keepalive_timeout   65;
    types_hash_max_size 4096;

    include             /etc/nginx/mime.types;
    default_type        application/octet-stream;

    # Load modular configuration files from the /etc/nginx/conf.d directory.
    # See http://nginx.org/en/docs/ngx_core_module.html#include
    # for more information.
    
	include /etc/nginx/conf.d/*.conf;

#     server {
#         listen       80;
#         listen       [::]:80;
#         server_name  _;
#         root         /usr/share/nginx/html;

#         # Load configuration files for the default server block.
#         include /etc/nginx/default.d/*.conf;

#         error_page 404 /404.html;
#         location = /404.html {
#         }

#         error_page 500 502 503 504 /50x.html;
#         location = /50x.html {
#         }
#     }
        server {
                listen 80;

                server_name www.hoangcodedao.io.vn hoangcodedao.io.vn;
                return       301 https://hoangcodedao.io.vn$request_uri;
        }

        server {
        listen       443 ssl http2;
        server_name  www.hoangcodedao.io.vn;
        return       301 https://hoangcodedao.io.vn$request_uri;
                ssl_certificate /etc/nginx/ssl/ssl_combined.crt;
                ssl_certificate_key /etc/nginx/ssl/ssl.key;
                ssl_trusted_certificate /etc/nginx/ssl/ssl.ca;
        }

        server {
                listen 443 ssl http2;
                ssl_certificate /etc/nginx/ssl/ssl_combined.crt;
                ssl_certificate_key /etc/nginx/ssl/ssl.key;
                ssl_session_cache shared:SSL:10m;
                ssl_session_timeout 10m;
                ssl_stapling on;
                ssl_stapling_verify on;
                ssl_trusted_certificate /etc/nginx/ssl/ssl.ca;
                ssl_buffer_size 1400;
                ssl_session_tickets on;

                # access_log off;
                access_log /home/hoangcodedao.io.vn/logs/access.log;
                # error_log off;
                error_log /home/hoangcodedao.io.vn/logs/error.log;

                root /home/hoangcodedao.io.vn/public_html;
                index index.php index.html index.htm;
                server_name hoangcodedao.io.vn;

                # Custom configuration
                # include /home/hoangcodedao.io.vn/public_html/*.conf;

                location / {
                        try_files $uri $uri/ /index.php?$args;
                }

                location = /favicon.ico {
                        log_not_found off;
                        access_log off;
                }

                location = /robots.txt {
                        allow all;
                        log_not_found off;
                        access_log off;
                }

                location ~* \.(3gp|gif|jpg|jpeg|png|ico|wmv|avi|asf|asx|mpg|mpeg|mp4|pls|mp3|mid|wav|swf|flv|exe|zip|tar|rar|gz|tgz|bz2|uha|7z|doc|docx|xls|xlsx|pdf|iso|eot|svg|ttf|woff)$ {
                        gzip_static off;
                        add_header Pragma public;
                        add_header Cache-Control "public, must-revalidate, proxy-revalidate";
                        access_log off;
                        expires 30d;
                        break;
                }

                location ~* \.(txt|js|css)$ {
                        add_header Pragma public;
                        add_header Cache-Control "public, must-revalidate, proxy-revalidate";
                        access_log off;
                        expires 30d;
                        break;
                }
        }

# Settings for a TLS enabled server.
#
#    server {
#        listen       443 ssl http2;
#        listen       [::]:443 ssl http2;
#        server_name  _;
#        root         /usr/share/nginx/html;
#
#        ssl_certificate "/etc/pki/nginx/server.crt";
#        ssl_certificate_key "/etc/pki/nginx/private/server.key";
#        ssl_session_cache shared:SSL:1m;
#        ssl_session_timeout  10m;
#        ssl_ciphers PROFILE=SYSTEM;
#        ssl_prefer_server_ciphers on;
#
#        # Load configuration files for the default server block.
#        include /etc/nginx/default.d/*.conf;
#
#        error_page 404 /404.html;
#            location = /40x.html {
#        }
#
#        error_page 500 502 503 504 /50x.html;
#            location = /50x.html {
#        }
#    }

}

