package com.ld42.game.ecs.core;

import java.util.Objects;

public abstract class GameObject {

    protected Engine engine = null;

    private String name;

    public GameObject(Engine engine, String name) {
        setEngine(engine);
        setName(name);
    }

    public void create() {}

    public void despose() {}

    public void setEngine(Engine engine) {
        if(this.engine == null)
            this.engine = engine;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        GameObject that = (GameObject) o;
        return Objects.equals(engine, that.engine) &&
                Objects.equals(name, that.name);
    }

    @Override
    public int hashCode() {

        return Objects.hash(engine, name);
    }

    @Override
    public String toString() {
        return "GameObject{" +
                "engine=" + engine +
                ", name='" + name + '\'' +
                '}';
    }
}
