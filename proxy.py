from mitmproxy import http
from mitmproxy import ctx
from mitmproxy.proxy import layer, layers

def load(loader):
    # ctx.options.web_open_browser = False
    # We change the connection strategy to lazy so that next_layer happens before we actually connect upstream.
    ctx.options.connection_strategy = "lazy"
    ctx.options.upstream_cert = False
    ctx.options.ssl_insecure = True
    
def next_layer(nextlayer: layer.NextLayer):
    # ctx.log(
    #     f"{nextlayer.context=}\n"
    #     f"{nextlayer.data_client()[:70]=}\n"
    # )
    # this is HTTPS only
    sni = nextlayer.context.client.sni
    if sni and (sni.endswith("kurogame.net") or sni.endswith("kurogame-service.com")):
        ctx.log('sni:' + sni)
        nextlayer.context.server.address = ("127.0.0.1", 443)

def request(flow: http.HTTPFlow) -> None:
    if "kurogame.net" in flow.request.pretty_url:
        flow.request.host = "localhost"
        flow.request.headers["Host"] = "localhost"
    pass
