namespace DataManager;

// public class EnvSettings
// {
//     public List<OneEnv> EnvSets { get; set; }
// }

public class EnvSettings
{
    public string Name { get; set; }
    public RabbitMQ RabbitMQ { get; set; }
    public Mongodb Mongodb { get; set; }
    public Elasticsearch Elasticsearch { get; set; }
    public Redis Redis { get; set; }
    
    public Apps Apps { get; set; }
}

public class RabbitMQ
{
    public string HostName { get; set; }
    public string Port { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ClientName { get; set; }
    public string ExchangeName { get; set; }
}
public class Mongodb
{
    public string Uri { get; set; }
    public string Dbname { get; set; }
}
public class Elasticsearch
{
    public string Uri { get; set; }
}
public class Redis
{
    public string Configuration { get; set; }
}

public class Apps
{
    public Aefinder Aefinder { get; set; }
}

public class Aefinder
{
    public string FinderSilo { get; set; }
    public string FinderSidechainEntityEventHandler { get; set; }
    public string FinderMainchainEntityEventHandler { get; set; }
    public string FinderSidechainBlockchaineventhandler { get; set; }
    public string FinderMainchainBlockchaineventhandler { get; set; }
    public string FinderBackgroundworker { get; set; }
    public string FinderHttpapiHost { get; set; }
    public string FinderAuthServer { get; set; }
    
}

// "finder-silo":"192.168.71.156:9999",
// "finder-sidechain-entity-event-handler":"192.168.71.156:9999",
// "finder-mainchain-entity-event-handler":"192.168.71.156:9999",
// "finder-sidechain-blockchaineventhandler":"192.168.71.156:9999",
// "finder-mainchain-blockchaineventhandler":"192.168.71.156:9999",
// "finder-backgroundworker":"192.168.71.156:9999",
// "finder-httpapi-host":"192.168.71.156:9999",
// "finder-auth-server":"192.168.71.156:9999"